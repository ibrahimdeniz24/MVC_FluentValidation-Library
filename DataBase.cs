using MVC_FluentValidation.Entites;

namespace MVC_FluentValidation
{
    public static class DataBase
    {
        //collection yapılarda bunları kullanmamız lazım yoksa içini dolduramayız.
        public static List<Passenger> passengers { get; set; } = new List<Passenger>();
    }
}
