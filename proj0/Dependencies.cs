// using System;
// using System.Collections.Generic;
// using System.IO;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using StoreApp.DbAccess;
// using StoreApplication;

// namespace proj0
// {
//   public class Dependencies : IDesignTimeDbContextFactory<StoreAppDbContext>, IDisposable
//   {
//     private bool _diposedValue;
//     private readonly List<IDisposable> _disposables = new List<IDisposable>();

//     public StoreAppDbContext CreateDbContext(String[] args = null)
//     {
//       var optionsBuilder = new DbContextOptionsBuilder<StoreAppDbContext>();
//       var connectionString = File.ReadAllText("C:/Revature/storeApp-connection-string.txt");
//       optionsBuilder.UtxtseSqlServer(connectionString);

//       return new StoreAppDbContext(optionsBuilder.Options);
//     }

//     public IStoreApp CreateStoreApp()
//     {
//       var dbContext = CreateDbContext();
//       _disposables.Add(dbContext);
//       return new StoreApp(dbContext);
//     }

//     protected virtual void Dispose(bool disposing)
//     {
//       if (!_diposedValue)
//       {
//         if (disposing)
//         {
//           foreach (IDisposable disposable in _disposables)
//           {
//             disposable.Dispose();
//           }
//         }
//         _diposedValue = true;
//       }
//     }

//     public void Dispose()
//     {
//       Dispose(disposing: true);
//       GC.SuppressFinalize(this);  // what does this do?
//     }
//   }
// }