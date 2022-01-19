namespace BingOnline.Persistencia.Modelo
{
    public class Numero
    {
        public int Codigo { get; set; }
        public bool Checked { get; set; }
        public Numero(int codigo) {
            Codigo = codigo;
            Checked = false;
        }
    }
}
