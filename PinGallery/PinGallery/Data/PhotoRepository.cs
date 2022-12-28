using PinGallery.Data.Tables;
using SQLite;
using System.Threading.Tasks;

namespace PinGallery.Data
{
    public class PhotoRepository
    {
        SQLiteAsyncConnection dbConnection;

        public PhotoRepository(string databasePath)
        {
            dbConnection = new SQLiteAsyncConnection(databasePath);
        }

        public async Task InitDatabase()
        {
            await dbConnection.CreateTableAsync<Photo>();
        }

        public async Task<Photo[]> GetPhotos()
        {
            return await dbConnection.Table<Photo>().ToArrayAsync();
        }

        public async Task<Photo> GetPhoto(int id)
        {
            return await dbConnection.GetAsync<Photo>(id);
        }

        public async Task<int> DeletePhoto(Photo photo)
        {
            return await dbConnection.DeleteAsync(photo);
        }

        public async Task<int> AddPhoto(Photo photo)
        {
            return await dbConnection.InsertAsync(photo);
        }
    }
}
