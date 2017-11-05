using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.QueryFilter
{
    public class QueryFilterFactory<T>
    {
        public IQueryable<T> QueryFieldContains(IQueryable<T> collection, string fieldName, object fieldValue)
        {
            IQueryable query = collection;
            Type[] exprArgTypes = { query.ElementType };

            var parameterExp = Expression.Parameter(typeof(T), "");
            var propertyExp = Expression.Property(parameterExp, fieldName);

            object value = fieldValue;

            if (propertyExp.Type.GetTypeInfo().IsEnum)
            {
                var m = typeof(Utils.Utilities).GetMethod("GetEnumValueFromEnumMember");
                var gm = m.MakeGenericMethod(propertyExp.Type);
                value = gm.Invoke(null, new[] { fieldValue });
            }

            object typedFieldValue = null;

            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(propertyExp.Type);
            //var values = Activator.CreateInstance(constructedListType);


            Dictionary<string, string> dateTimeOperators = new Dictionary<string, string>()
            {
                {"=", "op_Equality"},
                {"<>", "op_Inequality"},
                {">", "op_GreaterThan"},
                {">=", "op_GreaterThanOrEqual"},
                {"<", "op_LessThan"},
                {"<=", "op_LessThanOrEqual"}

                //{"=", "Equal"},
                //{"<>", "NotEqual"},
                //{">", "GreaterThan"},
                //{">=", "GreaterThanOrEqual"},
                //{"<", "LessThan"},
                //{"<=", "LessThanOrEqual"}

                //{"=", Expression.Equal},
                //{"<>", Expression.NotEqual},
                //{">", Expression.GreaterThan},
                //{">=", Expression.GreaterThanOrEqual},
                //{"<", Expression.LessThan},
                //{"<=", Expression.LessThanOrEqual}
            };
            var dateTimeOperator = dateTimeOperators["="];

            List<string> values = null;
            if (value is Newtonsoft.Json.Linq.JArray)
            {
                values = ((Newtonsoft.Json.Linq.JArray)value).ToObject<List<string>>();
                value = values.First();
                if (propertyExp.Type == typeof(DateTime))
                {
                    dateTimeOperator = dateTimeOperators[values[0]];
                    value = values[1];
                }
                //var containsMethodExp = Expression.Call(propertyExp, containsMethod, matchValue);
                //LambExpr = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
            }

            Type type = Nullable.GetUnderlyingType(propertyExp.Type) ?? propertyExp.Type;
            typedFieldValue = (value == null) ? null : Convert.ChangeType(value, type);

            //typedFieldValue = Convert.ChangeType(value, propertyExp.Type);
            var matchValue = Expression.Constant(typedFieldValue, propertyExp.Type);
            var equalExper = Expression.Equal(propertyExp, matchValue);

            Expression LambExpr = Expression.Lambda<Func<T, bool>>(equalExper, parameterExp);

            if (matchValue.Value is DateTime)
            {
                matchValue = Expression.Constant(((DateTime)typedFieldValue).Date, propertyExp.Type);
                //MethodInfo datetimeEqualsMethod = typeof(DateTime).GetMethod(dateTimeOperator);
                //var e = Expression.Property(propertyExp, "Date");
                //var equalsMethodExp = Expression.Call(datetimeEqualsMethod, e, matchValue);
                var equalsMethodExp = Expression.Equal(propertyExp, matchValue);
                if (dateTimeOperator == "op_Inequality") { equalsMethodExp = Expression.NotEqual(propertyExp, matchValue); }
                if (dateTimeOperator == "op_GreaterThan") { equalsMethodExp = Expression.GreaterThan(propertyExp, matchValue); }
                if (dateTimeOperator == "op_GreaterThanOrEqual") { equalsMethodExp = Expression.GreaterThanOrEqual(propertyExp, matchValue); }
                if (dateTimeOperator == "op_LessThan") { equalsMethodExp = Expression.LessThan(propertyExp, matchValue); }
                if (dateTimeOperator == "op_LessThanOrEqual") { equalsMethodExp = Expression.LessThanOrEqual(propertyExp, matchValue); }
                LambExpr = Expression.Lambda<Func<T, bool>>(equalsMethodExp, parameterExp);
            }

            //if (matchValue.Value is DateTime)
            //{
            //    MethodInfo datetimeEqualsMethod = typeof(DateTime).GetMethod("op_LessThanOrEqual");
            //    var equalsMethodExp = Expression.Call(datetimeEqualsMethod, matchValue, propertyExp);
            //    LambExpr = Expression.Lambda<Func<T, bool>>(equalsMethodExp, parameterExp);
            //}

            // this checks if value is an Array, form multiple values (in) or sitwing some new features, like >= and <=
            if (!(matchValue.Value is DateTime) && values != null && values.Count > 1)
            {
                MethodInfo containsMethod = typeof(IEnumerable<int>).GetMethod("Any");
                matchValue = Expression.Constant(values, values.GetType());
                var containsMethodExp = Expression.Call(matchValue, containsMethod, propertyExp);
                LambExpr = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
            }

            if (matchValue.Value is string)
            {
                MethodInfo containsMethod = typeof(string).GetMethod("Contains");
                var containsMethodExp = Expression.Call(propertyExp, containsMethod, matchValue);
                LambExpr = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
            }

            var methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, LambExpr);
            IQueryable q = query.Provider.CreateQuery(methodCall);
            return (IQueryable<T>)q;
        }
    }
}
