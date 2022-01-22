using System;
using System.Collections.Generic;
using System.Linq;
using AgendaDeReservas.Entities.Exceptions;
using AgendaDeReservas.Entities;

namespace AgendaDeReservas
{
    class Program
    {
        static void Main(string[] args)
        {
            Main:
            try
            {
                Console.Write("Número do Quarto: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Console.Write("Data do Check-In: (dd/mm/aaaa): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Data do Check-Out: (dd/mm/aaaa): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(roomNumber, checkIn, checkOut);
                Console.WriteLine("Reserva: " + reservation);

                Console.Write("\nDeseja atualizar a reserva?[s/n]"); //funcao secundaria de atualização
                char resp = char.Parse(Console.ReadLine());
                if (resp == 's' || resp == 'S')
                {
                    Console.Clear();
                    Console.WriteLine("Informe os dados da atualização da reserva:");
                    Console.Write("Data do Check-In: (dd/mm/aaaa): ");
                    checkIn = DateTime.Parse(Console.ReadLine());
                    Console.Write("Data do Check-Out: (dd/mm/aaaa): ");
                    checkOut = DateTime.Parse(Console.ReadLine());

                    reservation.UpdateDates(checkIn, checkOut);

                    Console.WriteLine("Reserva: " + reservation);
                }
            } catch (DomainException e)
            {
                Console.WriteLine("Erro na reserva" + e.Message);
                Console.ReadLine();
                Console.Clear();
                goto Main;
            } catch (FormatException)
            {
                Console.WriteLine("Erro no valor: Verifique o valor informado.");
                Console.ReadLine();
                Console.Clear();
                goto Main;
            }
            catch (Exception)
            {
                Console.WriteLine("Erro não esperado");
            }
        }
    }
}
