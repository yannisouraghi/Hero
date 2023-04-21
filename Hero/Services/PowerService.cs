using Hero.Models;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace Hero.Services
{
    public class PowerService
    {
        HeroContext _context { get; set; }
        public PowerService(HeroContext context) 
        {
            _context = context;
        }
        public async Task<List<Power>> getAllPowers()
        {
            var response = await _context.Powers.FindAsync();
            if (response == null)
            {
                return null;
            }
            return response;
        }
        public async Task<List<Power>> getPowers(int id)
        {
            var powers = await _context.Powers.FindAsync(id);
            if (powers == null)
            {
                return null;
            }
            return powers;
        }

        public async void addPower(Power power)
        {
            await _context.Powers.AddAsync(power);
        }

        public async void updatePower(Power power)
        {
            await _context.Powers.Update(power);
        }

        public async void deletePower(Power power)
        {
            await _context.Powers.ExecuteDeleteAsync(power);
        }
    }
}
