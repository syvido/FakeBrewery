﻿using System.Threading.Tasks;
using FakeBrewery.Application.Dtos;
using FakeBrewery.Domain.Models;

namespace FakeBrewery.Application.Interfaces
{
    public interface IWholesalerService
    {
        /// <summary>Add a new stock of a beer for a specific wholesaler.</summary>
        /// <param name="newStock">The new stock to add.</param>
        /// <returns>
        ///     A success result with the new stock as value.<br />
        ///     A failure result with Validation as error code if newStock has params validation errors.<br />
        ///     A failure result with NotFound as error code if the wholesaler or the beer does not exist.
        /// </returns>
        Task<Result<Stock>> AddStockAsync(Stock newStock);

        /// <summary>Update the stock of a beer for a specific wholesaler.</summary>
        /// <param name="stockToUpdate">The stock to update.</param>
        /// <returns>
        ///     A success result with the new stock as value.<br />
        ///     A failure result with Validation as error code if stock has params validation errors.<br />
        ///     A failure result with NotFound as error code if the stock does not exist.
        /// </returns>
        Task<Result<Stock>> UpdateStockAsync(Stock stockToUpdate);

        /// <summary>Calculate an estimate from an order</summary>
        /// <param name="order">The order to calculate.</param>
        /// <returns>
        ///     A success result with the estimate as value.<br />
        ///     A failure result with Validation as error code if order has validation errors.<br />
        ///     A failure result with NotFound as error code if the wholesaler or any beers do not exist.<br />
        ///     A failure result with Business as error code if order asks for beers not sold by the wholesaler.
        /// </returns>
        Task<Result<Estimate>> CalculateEstimate(Order order);
    }
}