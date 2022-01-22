﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgendaDeReservas.Entities;

namespace AgendaDeReservas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Número do Quarto: ");
            int roomNumber = int.Parse(Console.ReadLine());
            Console.Write("Data do Check-In: (dd/mm/aaaa): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Data do Check-Out: (dd/mm/aaaa): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            if (checkOut <= checkIn) //comparação das datas informadas
            {
                Console.WriteLine("Erro na Reserva: Data de Check-Out anterior ao Check-In");
            }
            else
            {
                Reservation reservation = new Reservation(roomNumber, checkIn, checkOut);
                Console.WriteLine("Reserva: "+ reservation);

                Console.Write("\nDeseja atualizar a reserva?[s/n]"); //funcao secundaria de atualização
                char resp = char.Parse(Console.ReadLine());
                if (resp == 's'|| resp == 'S')
                {
                    Console.Clear();
                    Console.WriteLine("Informe os dados da atualização da reserva:");
                    Console.Write("Data do Check-In: (dd/mm/aaaa): ");
                    checkIn = DateTime.Parse(Console.ReadLine());
                    Console.Write("Data do Check-Out: (dd/mm/aaaa): ");
                    checkOut = DateTime.Parse(Console.ReadLine());

                    string error = reservation.UpdateDates(checkIn, checkOut);

                    if (error != null)
                    {
                        Console.WriteLine(error);
                    }
                    else
                    {
                        Console.WriteLine("Reserva: " + reservation);
                    }
                    }
            }
        }
    }
}
