﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMalaPronta.Data.UnitOfWork
{
    /// <summary>
    ///     Interface for Unity of Work Pattern.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Perform updates.
        /// </summary>
        /// <returns>Returns an integer.</returns>
        int SaveChanges();

        /// <summary>
        ///     Perform updates, setting the command timeout for this operation only.
        /// </summary>
        /// <param name="timeout">The timeout to complete the save.</param>
        /// <returns>Returns an integer.</returns>
        int SaveChanges(int timeout);
    }
}
