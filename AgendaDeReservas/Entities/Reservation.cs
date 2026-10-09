using System;
using AgendaDeReservas.Entities.Exceptions;
using AgendaDeReservas.Entities.Enums;

namespace AgendaDeReservas.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public string ClientName { get; set; }
        public double PricePerNight { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }

        public Reservation()
        {
        }

        public Reservation(int roomNumber, string clientName, double pricePerNight, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("Data de Check-Out anterior ao Check-In");
            }
            RoomNumber = roomNumber;
            ClientName = clientName;
            PricePerNight = pricePerNight;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Status = ReservationStatus.Confirmed;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn); // utilizo uma variavel tipo TimeSpan para receber a diferença entre as datas (funao subtract do tipo DataTime)
            return (int)duration.TotalDays; //faco a conversao do TimeSpan para int e chamo a propriedade TotalDays para converter de ticks para dias
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            if (Status == ReservationStatus.Cancelled)
            {
                throw new DomainException("Não é possível atualizar uma reserva cancelada.");
            }

            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("As datas para atualização devem ser datas futuras.");
            }
            if (checkOut <= checkIn)
            {
                throw new DomainException("Data de Check-Out anterior ao Check-In");
            }
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public double TotalPrice()
        {
            return Duration() * PricePerNight;
        }

        public void Cancel()
        {
            if (Status == ReservationStatus.Cancelled)
            {
                throw new DomainException("A reserva já está cancelada.");
            }
            Status = ReservationStatus.Cancelled;
        }

        public override string ToString()
        {
            return "Hóspede: " + ClientName +
                ", Quarto " + RoomNumber +
                ", Check-in: " + CheckIn.ToString("dd/MM/yyyy") +
                ", Check-out: " + CheckOut.ToString("dd/MM/yyyy") +
                ", " + Duration() + " noites" +
                ", Status: " + Status +
                ", Valor Total: R$ " + TotalPrice().ToString("F2");
        }
    }
}
