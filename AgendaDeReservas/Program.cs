using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgendaDeReservas.Entities;
using AgendaDeReservas.Entities.Exceptions;

namespace AgendaDeReservas
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("--- NOVA RESERVA ---");
                Console.Write("Nome do Hóspede: ");
                string clientName = Console.ReadLine();
                Console.Write("Número do Quarto: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Console.Write("Valor da Diária: R$ ");
                double pricePerNight = double.Parse(Console.ReadLine());
                Console.Write("Data do Check-In: (dd/mm/aaaa): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Data do Check-Out: (dd/mm/aaaa): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(roomNumber, clientName, pricePerNight, checkIn, checkOut);
                Console.WriteLine("\nReserva Criada:\n" + reservation);

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1 - Atualizar datas da reserva");
                    Console.WriteLine("2 - Cancelar reserva");
                    Console.WriteLine("0 - Sair");
                    Console.Write("Opção: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("--- ATUALIZAR RESERVA ---");
                            Console.Write("Nova Data do Check-In: (dd/mm/aaaa): ");
                            checkIn = DateTime.Parse(Console.ReadLine());
                            Console.Write("Nova Data do Check-Out: (dd/mm/aaaa): ");
                            checkOut = DateTime.Parse(Console.ReadLine());

                            reservation.UpdateDates(checkIn, checkOut);
                            Console.WriteLine("\nReserva Atualizada:\n" + reservation);
                            break;
                        case "2":
                            Console.Clear();
                            reservation.Cancel();
                            Console.WriteLine("Reserva Cancelada com sucesso!");
                            Console.WriteLine("Reserva: " + reservation);
                            break;
                        case "0":
                            exit = true;
                            Console.WriteLine("Encerrando...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }
            catch (DomainException e)
            {
                Console.WriteLine("\nErro na Reserva: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Erro de formatação: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro inesperado: " + e.Message);
            }
        }
    }
}
