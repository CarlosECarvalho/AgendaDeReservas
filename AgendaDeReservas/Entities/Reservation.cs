using System;

namespace AgendaDeReservas.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation()
        {
        }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn); // utilizo uma variavel tipo TimeSpan para receber a diferença entre as datas (funao subtract do tipo DataTime)
            return (int)duration.TotalDays; //faco a conversao do TimeSpan para int e chamo a propriedade TotalDays para converter de ticks para dias
        }

        public void UpdateDates ( DateTime checkIn, DateTime checkOut)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
        }


        public override string ToString()
        {
            return "Quarto " + RoomNumber + ", Check-in: " + CheckIn.ToString("dd/MM/yyyy") + ", Check-out: " + CheckOut.ToString("dd/MM/yyyy") + ", " + Duration() + " noites."; //uso o ToString nas datas para formatar a exibicao
        }
    }
}
