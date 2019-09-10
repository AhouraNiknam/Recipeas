using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FinalProject
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UserDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserModel>().Wait();
        }
        public Task<int> SaveItemAsync(UserModel item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<UserModel> CheckUsername (string uName)
        {
            return database.Table<UserModel>().Where(i => i.UserName == uName).FirstOrDefaultAsync();
        }
        public Task<UserModel> CheckValid(string uName, string pass)
        {
            return database.Table<UserModel>().Where(i => i.UserName == uName & i.Password == pass).FirstOrDefaultAsync();
        }
        public Task<UserModel> RetrievePassword(string uName)
        {
            return database.Table<UserModel>().Where(i => i.UserName == uName).FirstOrDefaultAsync();
        }
    }
}
