using Microsoft.EntityFrameworkCore;
using RozkladJazdyBlazor.Data;
namespace RozkladJazdyBlazor.Components.Pages
{
	public partial class Timetable
	{
		private PolregioContext? _context;
		public List<TimetableSearch> timetable { get; set; } = new List<TimetableSearch>();
		public async Task ShowTimetable()
		{
			_context ??= await PolregioContextFactory.CreateDbContextAsync();

			if (_context is not null)
			{
				string start_name = SearchStartStation;
				string end_name = SearchEndStation;
				string date = SearchDateSelected;
				var start = (
							 from a in _context.Trips
							 join b in _context.Stop_Times on a.trip_id equals b.trip_id
							 join c in _context.Calendar_Dates on a.trip_id equals c.service_id
							 join d in _context.Stops on b.stop_id equals d.stop_id
							 where d.stop_name == start_name
							 where c.date == date
							 select new
							 {
								 Trip_Id = a.trip_id,
								 Stop_Name = d.stop_name,
								 Arrival = b.arrival_time,
								 Departure = b.departure_time,
								 Short_name = a.trip_short_name,
								 Wheelchair = a.wheelchair_accessible,
								 Bikes = a.bikes_allowed
							 }
							 ).ToList();
				var end = (
							 from a in _context.Trips
							 join b in _context.Stop_Times on a.trip_id equals b.trip_id
							 join c in _context.Calendar_Dates on a.trip_id equals c.service_id
							 join d in _context.Stops on b.stop_id equals d.stop_id
							 where d.stop_name == end_name
							 where c.date == date
							 select new
							 {
								 Trip_Id = a.trip_id,
								 Stop_Name = d.stop_name,
								 Arrival = b.arrival_time,
								 Departure = b.departure_time,
								 Short_name = a.trip_short_name,
								 Wheelchair = a.wheelchair_accessible,
								 Bikes = a.bikes_allowed
							 }
							 ).ToList();

				var timetable1 = (from a in start
								  join b in end on a.Trip_Id equals b.Trip_Id
								  let dep = Convert.ToDateTime(a.Departure)
								  let arr = Convert.ToDateTime(b.Arrival)
								  orderby dep
								  where dep < arr
								  select new
								  {
									  trip_id = a.Trip_Id,
									  start_name = a.Stop_Name,
									  end_name = b.Stop_Name,
									  start_departure_time = a.Departure,
									  end_arrival_time = b.Arrival,
									  trip_short_name = a.Short_name,
									  wheelchair_accessible = a.Wheelchair,
									  bikes_allowed = a.Bikes
								  }).ToList();

				for (int i = 0; i < timetable1.Count(); i++)
				{
					TimetableSearch tmp = new TimetableSearch();
					tmp.trip_id = timetable1[i].trip_id;
					tmp.start_name = timetable1[i].start_name;
					tmp.end_name = timetable1[i].end_name;
					tmp.start_departure_time = timetable1[i].start_departure_time;
					tmp.end_arrival_time = timetable1[i].end_arrival_time;
					tmp.trip_short_name = timetable1[i].trip_short_name;
					tmp.wheelchair_accessible = timetable1[i].wheelchair_accessible;
					tmp.bikes_allowed = timetable1[i].bikes_allowed;
					trips_ids.Add(tmp.trip_id);
					timetable.Add(tmp);
				}
			}

			if (_context is not null) await _context.DisposeAsync();
		}
	}
}
