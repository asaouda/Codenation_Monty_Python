using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var query = _context.Quotes.ToList();
            if (query == null)
                return null;

            var RamdomIndex = _randomService.RandomInteger(query.Count);
            var retorno = query.Skip(RamdomIndex).FirstOrDefault();
            return retorno;
        }

        public Quote GetAnyQuote(string actor)
        {
            var query = _context.Quotes.Where(x => x.Actor == actor).ToList();
            if (query == null)
                return null;

            var RamdomIndex = _randomService.RandomInteger(query.Count);
            var retorno = query.Skip(RamdomIndex).FirstOrDefault();
            return retorno;
        }
    }
}