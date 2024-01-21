using ConsoleApp1.İnterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class MicrosoftExtensions
    {
        public static List<T> FindAll<T>(this IList<T> values, Predicate<T> predicate)
        {
            return values.ToList().FindAll(predicate);
        }
        public static T? Find<T>(this IList<T> values, Predicate<T> predicate)
        {
            return values.ToList().Find(predicate);
        }


        public static void AddToDictionary<TKey, TValue>(
            this IDictionary<TKey, TValue> values,
            IList<TValue> users,
            IDictionary<TKey, IList<TKey>> indexes
            )
            where TValue : IUserBase
            where TKey : notnull
        {
            TKey castToKey(object key)
            {
                return (TKey)key;
            };
            void addIndex(object findKeyObject, TKey dataKey)
            {
                TKey findKey = castToKey(findKeyObject);
                if (indexes.ContainsKey(findKey))
                {
                    indexes[findKey].Add(dataKey);
                }
                else
                {
                    indexes.Add(findKey, new List<TKey>() { dataKey });
                }
            };
            users?.ToList().ForEach(user =>
            {
                TKey key = castToKey(user.UserName);
                values.Add(key, user);
                addIndex(user.UserName, key);
                addIndex(user.FirstName, key);
                addIndex(user.LastName, key);
                addIndex(user.IdentityNo, key);


                var personal = user.CastTo<IPersonal>();
                var student = user.CastTo<IStudent>();
                var jobber = user.CastTo<IJobber>();
                if (personal != null)
                {
                    addIndex(personal.SSN, key);
                    addIndex(personal.Salary.ToString(), key);
                }
                if (student != null)
                {
                    addIndex(student.StudentNo, key);
                    addIndex(student.Absenteeism.ToString(), key);
                    addIndex(student.Marks.ToString(), key);
                }
                if (jobber != null)
                {
                    addIndex(jobber.WorkArea, key);
                    addIndex(jobber.LicensePlate, key);
                }
            });
        }

        private static void addIndex<TKey>(object ıdentityNo, TKey key) where TKey : notnull
        {
            throw new NotImplementedException();
        }

        public static TObject? CastTo<TObject>(this object value)
            where TObject : class
        {
            if (value is TObject)
            {
                return value as TObject;
            }
            return null;
        }
    }
}
