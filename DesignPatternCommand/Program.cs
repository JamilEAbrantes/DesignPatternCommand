using System;
using System.Collections.Generic;

namespace CommandDesignPattern05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sair_Com_O_Carro();
            Console.WriteLine();
            Estacionar_O_Carro();

            Console.ReadKey();
        }

        private static void Sair_Com_O_Carro()
        {
            var comandos = new List<Action>
            {
                () => EletricaCommand.Status(),
                () => EletricaCommand.LigarCarro(),
                () => RotacaoCommand.VirarParaEsquerda(60),
                () => MoverCommand.MoverParaFrente(4),
                () => RotacaoCommand.NivelarDirecao(),
                () => MoverCommand.MoverParaFrente(100)
            };

            Executar.ExecutarComandos(comandos);
        }

        private static void Estacionar_O_Carro()
        {
            var comandos = new List<Action>
            {
                () => RotacaoCommand.VirarParaDireita(70),
                () => MoverCommand.MoverParaFrente(5),
                () => RotacaoCommand.NivelarDirecao(),
                () => MoverCommand.MoverParaTras(2),
                () => EletricaCommand.DesligarCarro(),
                () => EletricaCommand.Status()
            };

            Executar.ExecutarComandos(comandos);
        }
    }

    #region --> Commandos

    public static class Executar
    {
        public static void ExecutarComandos(IEnumerable<Action> comandos)
        {
            foreach (var comando in comandos)
                comando();
        }

        public static void DesfazerComandos(IEnumerable<Action> comandos)
        {
            foreach (var comando in comandos)
                comando();
        }
    }

    public static class EletricaCommand
    {
        private static bool Ligado { get; set; }

        public static void LigarCarro()
            => Console.WriteLine($"Ligar carro: { Ligado = true }.");

        public static void DesligarCarro()
            => Console.WriteLine($"Desligar carro: { Ligado = false }.");

        public static void Status()
        {
            if (Ligado)
                Console.WriteLine($"Veículo ligado.");
            else
                Console.WriteLine($"Veículo desligado.");
        }
    }

    public static class RotacaoCommand
    {
        public static void VirarParaDireita(double graus)
            => Console.WriteLine($"Virar p/ direita: { graus } graus.");

        public static void VirarParaEsquerda(double graus)
            => Console.WriteLine($"Virar p/ esquerda: { graus } graus.");

        public static void NivelarDirecao()
            => Console.WriteLine($"Direção nivelada: 0 graus.");
    }

    public static class MoverCommand
    {
        public static void MoverParaFrente(double metros)
            => Console.WriteLine($"Mover p/ frente: { metros } metros.");

        public static void MoverParaTras(double metros)
            => Console.WriteLine($"Mover p/ tras: { metros } metros.");
    }

    #endregion
}
