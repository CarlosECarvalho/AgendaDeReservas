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

        public string UpdateDates ( DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now; // logica de atualização da reserva implementada na funcao propria, porem ainda usando condicionais
            if (checkIn < now || checkOut < now)
            {
                return "Erro na Reserva: As datas para atualização devem ser datas futuras."; //retornos de funcao que seriam desnecessarios
            }
            if (checkOut <= checkIn)
            {
                return "Erro na Reserva: Data de Check-Out anterior ao Check-In";
            }
            CheckIn = checkIn;
            CheckOut = checkOut;
            return null;
        }


        public override string ToString()
        {
            return "Quarto " + RoomNumber + ", Check-in: " + CheckIn.ToString("dd/MM/yyyy") + ", Check-out: " + CheckOut.ToString("dd/MM/yyyy") + ", " + Duration() + " noites."; //uso o ToString nas datas para formatar a exibicao
        }
    }
}
