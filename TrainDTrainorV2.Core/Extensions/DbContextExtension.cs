using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Extensions
{
    public static class DbContextExtension
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);
            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);
            return !total.Except(applied).Any();
        }
        public static void EnsureSeeded(this TrainDTrainorContext context)
        {
            if (context.CheckTableExists<Role>())
            {
                if (!context.Roles.Any())
                {
                    var roles = JsonConvert.DeserializeObject<List<Role>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "Roles.json"));
                    context.AddRange(roles);
                    context.SaveChanges();
                }
            }
            if (context.CheckTableExists<User>())
            {
                if (!context.Users.Any())
                {
                    var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "Users.json"));
                    context.AddRange(users);
                    context.SaveChanges();
                }
            }
            if (context.CheckTableExists<UserProfile>())
            {
                if (!context.UserProfiles.Any())
                {
                    var usersprofile = JsonConvert.DeserializeObject<List<UserProfile>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "UsersProfile.json"));
                    context.AddRange(usersprofile);
                    context.SaveChanges();
                }
            }
            if (context.CheckTableExists<UserRole>())
            {
                if (!context.UserRoles.Any())
                {
                    var userroles = JsonConvert.DeserializeObject<List<UserRole>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "UserRoles.json"));
                    context.AddRange(userroles);
                    context.SaveChanges();
                }
            }
            if (context.CheckTableExists<RefreshToken>())
            {
                if (!context.RefreshTokens.Any())
                {
                    var userroles = JsonConvert.DeserializeObject<List<RefreshToken>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "RefreshToken.json"));
                    context.AddRange(userroles);
                    context.SaveChanges();
                }
            }
            if (context.CheckTableExists<UserLogin>())
            {
                if (!context.UserLogins.Any())
                {
                    var userroles = JsonConvert.DeserializeObject<List<UserLogin>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "UserLogins.json"));
                    context.AddRange(userroles);
                    context.SaveChanges();
                }
            }
            if (context.CheckTableExists<Training>())
            {
                if (!context.Training.Any())
                {
                    var trainings = JsonConvert.DeserializeObject<List<Training>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "Training.json"));
                    context.AddRange(trainings);
                    context.SaveChanges();
                }
            }
            if (context.CheckTableExists<Level>())
            {
                if (!context.Levels.Any())
                {
                    var trainings = JsonConvert.DeserializeObject<List<Level>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "Levels.json"));
                    context.AddRange(trainings);
                    context.SaveChanges();
                }
            }
            if (context.CheckTableExists<Country>())
            {
                if (!context.Countries.Any())
                {
                    var countries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText("DataSeeds" + Path.DirectorySeparatorChar + "Countries.json"));
                    context.AddRange(countries);
                    context.SaveChanges();
                }
            }
        }
        public static bool CheckTableExists<T>(this TrainDTrainorContext context) where T : class
        {
            try
            {
                context.Set<T>().Count();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public static DbCommand LoadStoredProc(this DbContext context, string storedProcName, bool prependDefaultSchema = true, short commandTimeout = 30)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandTimeout = commandTimeout;
            if (prependDefaultSchema)
            {
                var schemaName = context.Model.Relational().DefaultSchema;
                if (schemaName != null)
                {
                    storedProcName = $"{schemaName}.{storedProcName}";
                }
            }
            cmd.CommandText = storedProcName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            return cmd;
        }
        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, object paramValue, Action<DbParameter> configureParam = null)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = (paramValue != null ? paramValue : DBNull.Value);
            configureParam?.Invoke(param);
            cmd.Parameters.Add(param);
            return cmd;
        }
        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, Action<DbParameter> configureParam = null)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            configureParam?.Invoke(param);
            cmd.Parameters.Add(param);
            return cmd;
        }
        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, SqlParameter parameter)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
                throw new InvalidOperationException("Call LoadStoredProc before using this method");
            cmd.Parameters.Add(parameter);
            return cmd;
        }
        public class SprocResults
        {

            //  private DbCommand _command;
            private DbDataReader _reader;

            public SprocResults(DbDataReader reader)
            {
                // _command = command;
                _reader = reader;
            }

            public IList<T> ReadToList<T>()
            {
                return MapToList<T>(_reader);
            }

            public T? ReadToValue<T>() where T : struct
            {
                return MapToValue<T>(_reader);
            }

            public Task<bool> NextResultAsync()
            {
                return _reader.NextResultAsync();
            }

            public Task<bool> NextResultAsync(CancellationToken ct)
            {
                return _reader.NextResultAsync(ct);
            }

            public bool NextResult()
            {
                return _reader.NextResult();
            }

            /// <summary>
            /// Retrieves the column values from the stored procedure and maps them to <typeparamref name="T"/>'s properties
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="dr"></param>
            /// <returns>IList<<typeparamref name="T"/>></returns>
            private IList<T> MapToList<T>(DbDataReader dr)
            {
                var objList = new List<T>();
                var props = typeof(T).GetRuntimeProperties().ToList();

                var colMapping = dr.GetColumnSchema()
                    .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                    .ToDictionary(key => key.ColumnName.ToLower());

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        T obj = Activator.CreateInstance<T>();
                        foreach (var prop in props)
                        {
                            if (colMapping.ContainsKey(prop.Name.ToLower()))
                            {
                                var column = colMapping[prop.Name.ToLower()];

                                if (column?.ColumnOrdinal != null)
                                {
                                    var val = dr.GetValue(column.ColumnOrdinal.Value);
                                    prop.SetValue(obj, val == DBNull.Value ? null : val);
                                }

                            }
                        }
                        objList.Add(obj);
                    }
                }
                return objList;
            }

            /// <summary>
            ///Attempts to read the first value of the first row of the resultset.
            /// </summary>
            private T? MapToValue<T>(DbDataReader dr) where T : struct
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        return dr.IsDBNull(0) ? new T?() : new T?(dr.GetFieldValue<T>(0));
                    }
                }
                return new T?();
            }
        }
        public static void ExecuteStoredProc(this DbCommand command, Action<SprocResults> handleResults, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default, bool manageConnection = true)
        {
            if (handleResults == null)
            {
                throw new ArgumentNullException(nameof(handleResults));
            }

            using (command)
            {
                if (manageConnection && command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader(commandBehaviour))
                    {
                        var sprocResults = new SprocResults(reader);
                        // return new SprocResults();
                        handleResults(sprocResults);
                    }
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }
        }
        public async static Task ExecuteStoredProcAsync(this DbCommand command, Action<SprocResults> handleResults, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default, CancellationToken ct = default(CancellationToken), bool manageConnection = true)
        {
            if (handleResults == null)
            {
                throw new ArgumentNullException(nameof(handleResults));
            }

            using (command)
            {
                if (manageConnection && command.Connection.State == System.Data.ConnectionState.Closed)
                    await command.Connection.OpenAsync(ct).ConfigureAwait(false);
                try
                {
                    using (var reader = await command.ExecuteReaderAsync(commandBehaviour, ct).ConfigureAwait(false))
                    {
                        var sprocResults = new SprocResults(reader);
                        handleResults(sprocResults);
                    }
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }
        }
        public static int ExecuteStoredNonQuery(this DbCommand command, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default, bool manageConnection = true)
        {
            int numberOfRecordsAffected = -1;

            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                try
                {
                    numberOfRecordsAffected = command.ExecuteNonQuery();
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }

            return numberOfRecordsAffected;
        }
        public async static Task<int> ExecuteStoredNonQueryAsync(this DbCommand command, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default, CancellationToken ct = default(CancellationToken), bool manageConnection = true)
        {
            int numberOfRecordsAffected = -1;

            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    await command.Connection.OpenAsync(ct).ConfigureAwait(false);
                }

                try
                {
                    numberOfRecordsAffected = await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
                finally
                {
                    if (manageConnection)
                    {
                        command.Connection.Close();
                    }
                }
            }

            return numberOfRecordsAffected;
        }


        public static CreateResult CreateDir<T>(this TrainDTrainorContext context , T Entity) where T : class
        {
            var result = new CreateResult();

            context.LoadStoredProc(string.Format(@"dbo.{0}_CreateDir", typeof(T).Name))
                .WithSqlParam("@name", GetPropertyValue(Entity,"Name"))
                .WithSqlParam("@parentpath", GetPropertyValue(Entity, "ParentPath"))
                .ExecuteStoredProc((handler) => {
                    result = handler.ReadToList<CreateResult>().FirstOrDefault();
                });
            return result;
        }
        public static CreateResult CreateFile<T>(this TrainDTrainorContext context, T Entity) where T : class
        {
            var result = new CreateResult();
            context.LoadStoredProc(string.Format(@"dbo.{0}_CreateFile", typeof(T).Name))
                .WithSqlParam("@name", GetPropertyValue(Entity, "Name"))
                .WithSqlParam("@file_stream", GetPropertyValue(Entity, "File_stream"))
                .WithSqlParam("@parentpath", GetPropertyValue(Entity, "ParentPath"))               
                .ExecuteStoredProc((handler) => {
                    result = handler.ReadToList<CreateResult>().FirstOrDefault();
                });
            return result;
        }
        public static CreateResult UpdateFile<T>(this TrainDTrainorContext context, T Entity) where T : class
        {
            var result = new CreateResult();
            context.LoadStoredProc(string.Format(@"dbo.{0}_Update", typeof(T).Name))
                .WithSqlParam("@stream_id", GetPropertyValue(Entity, "Stream_id"))
                .WithSqlParam("@file_stream", GetPropertyValue(Entity, "File_stream"))               
                .ExecuteStoredProc((handler) => {
                    result = handler.ReadToList<CreateResult>().FirstOrDefault();
                });
            return result;
        }
        public static CreateResult FindFolder<T>(this TrainDTrainorContext context, T Entity) where T:class
        {
            var result = new CreateResult();
            context.LoadStoredProc(string.Format(@"dbo.{0}_Folder", typeof(T).Name))
                .WithSqlParam("@name", GetPropertyValue(Entity, "Name"))                
                .ExecuteStoredProc((handler) => {
                    result = handler.ReadToList<CreateResult>().FirstOrDefault();
                });
            return result;
        }
        private static object GetPropertyValue<T>(T item, string name) where T : class
        {
            Type t = item.GetType();
            PropertyInfo prop = t.GetProperty(name);
            object propertyValue = prop.GetValue(item);
            return propertyValue;
        }
        //public static InternalEntityEntry GetInternalEntityEntry(this EntityEntry entityEntry)
        //{
        //    var internalEntry = (InternalEntityEntry)entityEntry
        //        .GetType()
        //        .GetProperty("InternalEntry", BindingFlags.NonPublic | BindingFlags.Instance)
        //        .GetValue(entityEntry);

        //    return internalEntry;
        //}
        //public static void ApplyCascadeDeletes(this IEnumerable<EntityEntry> entities)
        //{
        //    foreach (var entry in entities.Where(
        //       e => (e.State == EntityState.Modified
        //       || e.State == EntityState.Added)
        //       && e.GetInternalEntityEntry().HasConceptualNull).ToList())
        //    {
        //        entry.GetInternalEntityEntry().HandleConceptualNulls(false);
        //    }

        //    foreach (var entry in entities.Where(e => e.State == EntityState.Deleted).ToList())
        //    {
        //        CascadeDelete(entry.GetInternalEntityEntry());
        //    }
        //}
        //private static void CascadeDelete(InternalEntityEntry entry)
        //{
        //    foreach (var fk in entry.EntityType.GetReferencingForeignKeys())
        //    {
        //        foreach (var dependent in (entry.StateManager.GetDependentsFromNavigation(entry, fk)
        //                 ?? entry.StateManager.GetDependents(entry, fk)).ToList())
        //        {
        //            if (dependent.EntityState != EntityState.Deleted
        //                && dependent.EntityState != EntityState.Detached)
        //            {
        //                if (fk.DeleteBehavior == DeleteBehavior.Cascade)
        //                {
        //                    var cascadeState = dependent.EntityState == EntityState.Added
        //                       ? EntityState.Detached
        //                       : EntityState.Deleted;

        //                    dependent.SetEntityState(cascadeState);

        //                    CascadeDelete(dependent);
        //                }
        //                else if (fk.DeleteBehavior != DeleteBehavior.Restrict)
        //                {
        //                    foreach (var dependentProperty in fk.Properties)
        //                    {
        //                        dependent[dependentProperty] = null;
        //                    }

        //                    if (dependent.HasConceptualNull)
        //                    {
        //                        dependent.HandleConceptualNulls(false);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}



    }
}
