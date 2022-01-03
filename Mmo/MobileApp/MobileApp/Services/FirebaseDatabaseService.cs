using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace Ole777.Services
{
    public class FirebaseDatabaseService : IFirebaseDatabaseService
    {
        private const string BaseUrl = "https://lksdjfas-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const string Auth = "phRns5lZP6v9GqjeYjaziyRJhwbsaUeYdEf4dVxb";

        private readonly FirebaseOptions _options;

        public FirebaseDatabaseService()
        {
            _options = new FirebaseOptions()
            {
                AuthTokenAsyncFactory = () => Task.FromResult(Auth)
            };

        }

        private ChildQuery Query<T>()
        {
            var name = typeof(T).FullName.Split('.').LastOrDefault();
            return new FirebaseClient(BaseUrl, _options).Child(name);
        }
        public async Task<bool> AddItemAsync<T>(T item)
        {
            try
            {
                await Query<T>()
                    .PostAsync(item);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateItemAsync<T>(string id, T item)
        {
            try
            {
                await Query<T>()
                    .Child(id)
                    .PutAsync(item);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteItemAsync<T>(string id)
        {
            try
            {
                await Query<T>()
                    .Child(id)
                    .DeleteAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<T> GetItemAsync<T>()
        {
            try
            {
                var data = await Query<T>().OnceAsync<T>();
                return (data?.FirstOrDefault()).Object;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>(bool forceRefresh = false)
        {
            try
            {
                var firebaseObjects = await Query<T>()
                    .OnceAsync<T>();

                return firebaseObjects
                    .Select(x => x.Object);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}