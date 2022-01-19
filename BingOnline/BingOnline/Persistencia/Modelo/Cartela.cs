namespace BingOnline.Persistencia.Modelo
{
    public class Cartela
    {
        public int Id { get; set; }
        public List<Numero> Numeros { get; set; }

        public Cartela()
        {
            Numeros = new List<Numero>();
        }

        private bool NumeroExiste(int num) {
            foreach (var numero in Numeros)
                if (numero.Codigo == num) 
                    return true;
            return false;
        }

        public void GerarNumeros() { 
            Numeros.Clear();

            Random random = new Random();

            for(int i = 1; i <= 25; i++) {
                int rng = 0;
                while (true)
                {
                    rng = random.Next(1, 99);
                    if (!NumeroExiste(rng))
                        break;
                }

                Numeros.Add(new Numero(rng));
            }
        }

        public void OrdenarNumeros()
        {
            List<Numero> CopyNumeros = new List<Numero>();
            foreach (var numero in Numeros)
                CopyNumeros.Add(new Numero(numero.Codigo));
            Numeros.Clear();

            Numero deletar = null;


            while (CopyNumeros.Count>0)
            {
                int menor = 999;
                foreach (var numero in CopyNumeros)
                {
                    if (numero.Codigo <= menor)
                    {
                        menor = numero.Codigo;
                        deletar = numero;
                    }
                }
                if (deletar != null)
                {
                    Numeros.Add(new Numero(deletar.Codigo));
                    CopyNumeros.Remove(deletar);
                }
            }
        }

    }
}
