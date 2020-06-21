using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class SqliteExtensions
    {
        /// <summary>
        ///     Inserts all specified objects.
        ///     For each insertion, if a UNIQUE
        ///     constraint violation occurs with
        ///     some pre-existing object, this function
        ///     deletes the old object.
        /// </summary>
        /// <param name="objects">
        ///     An <see cref="IEnumerable" /> of the objects to insert or replace.
        /// </param>
        /// <returns>
        ///     The total number of rows modified.
        /// </returns>
        public static async Task<int> InsertOrReplaceAll<T>(this SQLiteAsyncConnection connection, IEnumerable<T> objects, bool runInTransaction = true)
        {
            var c = 0;
            if (objects == null)
                return c;

            if (runInTransaction)
            {
                await connection.RunInTransactionAsync((con) =>
                {
                    foreach (var r in objects)
                    {
                        c += con.InsertOrReplace(r);
                    }
                });
            }
            else
            {
                foreach (var r in objects)
                {
                    c += await connection.InsertOrReplaceAsync(r, r.GetType());
                }


            }                
            return c;

        }
    }
}
