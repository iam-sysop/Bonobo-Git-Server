using gitserverdotnet.Configuration;
using gitserverdotnet.Data.Update.ADBackendUpdate;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Serilog;

namespace gitserverdotnet.Data.Update
{
    public class AutomaticUpdater
    {
        public void Run()
        {
            if (AuthenticationSettings.MembershipService.ToLowerInvariant() == "activedirectory")
            {
                Pre600UpdateTo600.UpdateADBackend();
            }
            else
            {
                UpdateDatabase();
            }
        }

        public void RunWithContext(gitserverdotnetContext context)
        {
            DoUpdate(context);
        }

        private void UpdateDatabase()
        {
            using (var ctx = new gitserverdotnetContext())
            {
                DoUpdate(ctx);
            }
        }

        private void DoUpdate(gitserverdotnetContext ctx)
        {
            IObjectContextAdapter ctxAdapter = ctx;
            var connectiontype = ctx.Database.Connection.GetType().Name;

            foreach (var item in UpdateScriptRepository.GetScriptsBySqlProviderName(connectiontype))
            {
                if (!string.IsNullOrEmpty(item.Precondition))
                {
                    try
                    {
                        var preConditionResult = ctxAdapter.ObjectContext.ExecuteStoreQuery<int>(item.Precondition).Single();
                        if (preConditionResult == 0)
                        {
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        // consider failures in pre-conditions as an indication that
                        // store ecommand should be executed
                    }
                }

                if (!string.IsNullOrEmpty(item.Command))
                {
                    try
                    {
                        ctxAdapter.ObjectContext.ExecuteStoreCommand(item.Command);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Exception while processing upgrade script {0}", item.Command);
                        throw;
                    }
                }

                item.CodeAction(ctx);
            }
        }
    }
}