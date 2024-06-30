using Microsoft.EntityFrameworkCore;
using RozkladJazdyBlazor.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;


namespace RozkladJazdyBlazor.Components.Pages
{
    public partial class DatabaseTest
    {
        private PolregioContext? _context;
        public List<Data.Routes>? OurAgencies { get; set; }

        public async Task ShowEmployees()
        {
            _context ??= await PolregioContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                OurAgencies = await _context.Routes.ToListAsync();
            }

            if (_context is not null) await _context.DisposeAsync();
        }
    }
}
