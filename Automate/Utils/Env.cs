using Automate.Interfaces;
using Automate.Utils.DataServices;

namespace Automate.Utils
{
    public static class Env
    {
        public readonly static MongoDBService mongoDBService = new MongoDBService();
        public readonly static UserService userService = new UserService(mongoDBService);
        public readonly static CalendarService calendarService = new CalendarService(mongoDBService);
        public readonly static WeatherConditionsService weatherConditionsService = new WeatherConditionsService();
        public static IUser? authenticatedUser;
    }
}
