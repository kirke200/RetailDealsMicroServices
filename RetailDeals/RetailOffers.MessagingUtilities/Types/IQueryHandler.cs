using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailOffers.MessagingUtilities.Types
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
