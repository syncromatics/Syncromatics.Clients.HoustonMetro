using System;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public class Arrival
    {
        public string AgencyId { get; set; }
        public string AgencyAbbreviation { get; set; }
        public string ArrivalId { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime LocalArrivalTime { get; set; }
        public DateTime LocalDepartureTime { get; set; }
        public DateTime UtcArrivalTime { get; set; }
        public DateTime UtcDepartureTime { get; set; }
        public string DestinationName { get; set; }
        public string DestinationStopId { get; set; }
        public string DirectionId { get; set; }
        public int Direction { get; set; }
        public string RouteId { get; set; }
        public string ServiceId { get; set; }
        public string StopId { get; set; }
        public string TripId { get; set; }
        public DateTime LocalTripStartTime { get; set; }
        public DateTime LocalTripEndTime { get; set; }
        public string StopName { get; set; }
        public int StopSequence { get; set; }
        public string RouteName { get; set; }
        public string RouteType { get; set; }
        public int? DelaySeconds { get; set; }
        public int CarCount { get; set; }
        public int Frequency { get; set; }
        public string DestinationStopName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string DirectionText { get; set; }
        public bool IsRealTime { get; set; }
    }
}
