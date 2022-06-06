using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace Plugins
{
    public class PluginAlunosValidacao: IPlugin
    {
       
            public void Execute(IServiceProvider serviceProvider)
            {
                IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

                IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

                IOrganizationService serviceAdmin = serviceFactory.CreateOrganizationService(null);

                ITracingService trace = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

                Entity entidadeContexto = null;
                if (context.InputParameters.Contains("Target"))
                {
                    entidadeContexto = (Entity)context.InputParameters["Target"];
                trace.Trace("Entidade do Contexto: " + entidadeContexto.Attributes.Count);
                trace.Trace("Entidade do Contexto contém CPF: " + entidadeContexto.Contains("eh_cpf"));

                if(entidadeContexto == null)
                {
                    return;
                }

                if (!entidadeContexto.Contains("telephone1"))
                {
                    throw new InvalidPluginExecutionException("Campo Telefone principal é obrigatório!");
                }


                /* 
                bool a = entidadeContexto.Equals("eh_cpf");

                if (a == true)
                {
                    throw new InvalidPluginExecutionException("CPF já cadastrado!");
                }
                */

            }
            }
        }
    }
