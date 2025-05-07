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
    }
}
