namespace RozkladJazdyBlazor.Data
{
	public class Agency
	{
		public int Id { get; set; }
		public string? agency_id { get; set; }
		public string? agency_name { get; set; }
		public string? agency_url { get; set; }
		public string? agency_lang { get; set; }
		public string? agency_timezone { get; set; }
		public string? agency_phone { get; set; }
		
	}
	public class Calendar_Dates
	{
        public int Id { get; set; }
        public string? service_id { get; set; }
		public string? date { get; set; }
		public string? exception_type { get; set; }
	}
	public class Routes
	{
        public int Id { get; set; }
        public string? agency_id { get; set; }
		public string? route_id { get; set; }
		public string? route_short_name { get; set; }
		public string? route_long_name { get; set; }
		public string? route_type { get; set; }
		public string? route_color { get; set; }
		public string? route_text_color { get; set; }
	}
	public class Stop_Times
	{
        public int Id { get; set; }
        public string? trip_id { get; set; }
		public string? stop_sequence { get; set; }
		public string? stop_id { get; set; }
		public string? arrival_time { get; set; }
		public string? departure_time { get; set; }
		public string? platform { get; set; }
		public string? official_dist_traveled { get; set; }
	}
	public class Stops
	{
        public int Id { get; set; }
        public string? stop_id { get; set; }
		public string? stop_name { get; set; }
		public string? stop_lat { get; set; }
		public string? stop_lon { get; set; }
		public string? stop_IBNR { get; set; }
	}
	public class Transfers
	{
        public int Id { get; set; }
        public string? from_stop_id { get; set; }
		public string? to_stop_id { get; set; }
		public string? from_trip_id { get; set; }
		public string? to_trip_id { get; set; }
		public string? transfer_type { get; set; }
	}
	public class Trips
	{
        public int Id { get; set; }
        public string? route_id { get; set; }
		public string? service_id { get; set; }
		public string? trip_id { get; set; }
		public string? trip_short_name { get; set; }
		public string? trip_headsign { get; set; }
		public string? wheelchair_accessible { get; set; }
		public string? bikes_allowed { get; set; }
	}
}
