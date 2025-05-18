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
    public class HomeRepository : IHomeRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public HomeRepository()
        {
            _context = new MiaDatabaseContext();
        }


        public async Task<Home> GetHomeAsync() {

            var homeEntity = await _context.Homes.ToListAsync();
            var homeModel = homeEntity.Select(h => new Home
            {
                 Id = h.Id,
                 Title = h.Title,
                 IdBanner = h.IdBanner,
                 IdImage = h.IdImage,
                 IdMedia = h.IdMedia,
                 
            }).ToList();

            return homeModel.FirstOrDefault();
        }




        public async Task<Home> UpdateHome(int IdHome, Home model)
        {

            try
            {
                var HomeToUpdate = await _context.Homes.FirstOrDefaultAsync(u => u.Id == IdHome);

                if (HomeToUpdate == null)
                    return null; // ou throw une exception

                // On met à jour ses propriétés
                if (model.Title != null) HomeToUpdate.Title = model.Title;
                if (model.IdBanner != null) HomeToUpdate.IdBanner = model.IdBanner;
                if (model.IdImage != null) HomeToUpdate.IdImage = model.IdImage;
                if (model.IdMedia != null) HomeToUpdate.IdMedia = model.IdMedia;

                await _context.SaveChangesAsync();

                return HomeToUpdate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }



        public async Task<Home> AddHome(Home model)
        {
            var newHome = new Home
            {
                Title = model.Title,
                IdBanner = model.IdBanner,
                IdMedia = model.IdMedia,
                IdImage = model.IdImage,
            };

            _context.Homes.Add(newHome);
            _context.SaveChanges();


            return newHome;
        }
    }
}
