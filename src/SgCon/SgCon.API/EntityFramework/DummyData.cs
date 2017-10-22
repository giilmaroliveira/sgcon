using SgCon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SgCon.API.EntityFramework
{
    public class DummyData
    {
        public static List<Condominio> getCondominios()
        {
            List<Condominio> condominios = new List<Condominio>()
            {
                new Condominio {
                    Descricao = "Condomínio 1",
                    Cnpj = "55473415000174",
                    NumPredios = 1
                },
                new Condominio {
                    Descricao = "Condomínio 2",
                    Cnpj = "39890187000181",
                    NumPredios = 1
                }
            };

            return condominios;
        }

        public static List<Predio> getPredios(SgConContext context)
        {
            List<Predio> predios = new List<Predio>()
            {
                new Predio {
                    Descricao = "Predio 1 Condomínio 1",
                    IdCondominio = context.Condominio.Find(1).Id
                },
                new Predio {
                    Descricao = "Predio 1 Condomínio 2",
                    IdCondominio = context.Condominio.Find(2).Id
                }
            };

            return predios;
        }
    }
}