using Microsoft.EntityFrameworkCore;
using RozkladJazdyBlazor.Data;
namespace RozkladJazdyBlazor.Components.Pages
{
	public partial class Connection
	{
		private PolregioContext? _context;
		public List<StopTimes> StopsTable = new();
		public async Task ShowInfo()
		{
			_context ??= await PolregioContextFactory.CreateDbContextAsync();

			if (_context is not null)
			{
				var stops = (from a in _context.Stop_Times
							 join b in _context.Stops
							 on a.stop_id equals b.stop_id
							 where a.trip_id == id
							 select new
							 {
								 b.stop_name,
								 a.arrival_time,
								 a.departure_time
							 }).ToList();
				foreach (var stop in stops)
				{
					StopTimes tmp = new StopTimes();
					tmp.Stop_Name = stop.stop_name;
					tmp.Arrival_Time = stop.arrival_time;
					tmp.Departure_Time = stop.departure_time;
					StopsTable.Add(tmp);
				}
			}
			if (_context is not null) await _context.DisposeAsync();
		}
	}
}
