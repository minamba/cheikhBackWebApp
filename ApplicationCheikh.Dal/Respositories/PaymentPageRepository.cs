using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Dal.Respositories
{
    public class PaymentPageRepository : IPaymentPageRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public PaymentPageRepository()
        {
            _context = new MiaDatabaseContext();
        }


        public async Task<PaymentPg> GetPaymentPg()
        {
            var result = await _context.PaymentPgs.FirstOrDefaultAsync();

            return result;
        }

        public async Task<PaymentPg> UpdatePaymentPg(int IRegistration, PaymentPg model)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var paymeentPgToUpdate = await _context.PaymentPgs.FirstOrDefaultAsync(u => u.Id == IRegistration);

            if (paymeentPgToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) paymeentPgToUpdate.Title = model.Title;
            if (model.IdBanner != null) paymeentPgToUpdate.IdBanner = model.IdBanner;

            await _context.SaveChangesAsync();

            return paymeentPgToUpdate;
        }
    }
}
