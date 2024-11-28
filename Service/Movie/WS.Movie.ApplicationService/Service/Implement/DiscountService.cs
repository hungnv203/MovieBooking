using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS.Movie.ApplicationService.Service.Abstract;
using WS.Movie.Domain;
using WS.Movie.Dtos;
using WS.Movie.Infrastructure;

namespace WS.Movie.ApplicationService.Service.Implement
{
    public class DiscountService : IDiscountService
    {
        private readonly ApplicationDbContext _context;

        public DiscountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiscountDto>> GetAllDiscountsAsync()
        {
            return await _context.Discounts.Select(d => new DiscountDto
            {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Percentage = d.Percentage,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                MaxUsage = d.MaxUsage
            }).ToListAsync();
        }

        public async Task<DiscountDto> GetDiscountByIdAsync(int id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null) return null;

            return new DiscountDto
            {
                Id = discount.Id,
                Code = discount.Code,
                Description = discount.Description,
                Percentage = discount.Percentage,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                MaxUsage = discount.MaxUsage
            };
        }

        public async Task<DiscountDto> CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
            var discount = new Discount
            {
                Code = createDiscountDto.Code,
                Description = createDiscountDto.Description,
                Percentage = createDiscountDto.Percentage,
                StartDate = createDiscountDto.StartDate,
                EndDate = createDiscountDto.EndDate,
                MaxUsage = createDiscountDto.MaxUsage
            };

            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();

            return new DiscountDto
            {
                Id = discount.Id,
                Code = discount.Code,
                Description = discount.Description,
                Percentage = discount.Percentage,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                MaxUsage = discount.MaxUsage
            };
        }

        public async Task<DiscountDto> UpdateDiscountAsync(int id, UpdateDiscountDto updateDiscountDto)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null) return null;

            discount.Description = updateDiscountDto.Description;
            discount.Percentage = updateDiscountDto.Percentage;
            discount.StartDate = updateDiscountDto.StartDate;
            discount.EndDate = updateDiscountDto.EndDate;
            discount.MaxUsage = updateDiscountDto.MaxUsage;

            await _context.SaveChangesAsync();

            return new DiscountDto
            {
                Id = discount.Id,
                Code = discount.Code,
                Description = discount.Description,
                Percentage = discount.Percentage,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                MaxUsage = discount.MaxUsage
            };
        }

        public async Task<bool> DeleteDiscountAsync(int id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null) return false;

            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ApplyDiscountAsync(int userId, string code)
        {
            var discount = await _context.Discounts.SingleOrDefaultAsync(d => d.Code == code);
            if (discount == null || discount.StartDate > DateTime.Now || discount.EndDate < DateTime.Now)
                return false;

            var usageCount = await _context.UserDiscounts.CountAsync(ud => ud.DiscountId == discount.Id);
            if (usageCount >= discount.MaxUsage)
                return false;

            var userDiscount = new UserDiscount
            {
                UserId = userId,
                DiscountId = discount.Id,
                Used = true,
                UsageDate = DateTime.Now
            };

            _context.UserDiscounts.Add(userDiscount);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
