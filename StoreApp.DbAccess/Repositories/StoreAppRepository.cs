using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
//using NLog;
using StoreApp.DbAccess;

namespace StoreApp.DataAccess.Repositores
{
  ///<summary>
  /// Repository for managing data access to StoreApp objects
  ///uses the Entity Framework
  ///</summary>
  ///
  public class StoreAppRepository
  {
    private readonly StoreProj0Context _dbContext;

    //private static readonly Ilogger s_logger = LogManager.GetCurrent
    public StoreAppRepository(StoreProj0Context dbContext)
    {
      _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    // public void AddCustomer(Library.Models.Customer customer)
    // {

    // }






  }

}

