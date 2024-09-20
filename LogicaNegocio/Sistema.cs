namespace LogicaNegocio
{
    public class Sistema
    {
        private static Sistema s_instancia;

        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }
        private Sistema() { }
    }
}
