namespace Pokémon
{
    public sealed class Type<T> where T : IType
    {
        public static Type<INormal> Normal => new Type<INormal>();
        public static Type<IFighting> Fighting => new Type<IFighting>();
        public static Type<IFlying> Flying => new Type<IFlying>();
        public static Type<IPoison> Poison => new Type<IPoison>();
        public static Type<IGround> Ground => new Type<IGround>();
        public static Type<IRock> Rock => new Type<IRock>();
        public static Type<IBug> Bug => new Type<IBug>();
        public static Type<IGhost> Ghost => new Type<IGhost>();
        public static Type<ISteel> Steel => new Type<ISteel>();
        public static Type<IFire> Fire => new Type<IFire>();
        public static Type<IWater> Water => new Type<IWater>();
        public static Type<IGrass> Grass => new Type<IGrass>();
        public static Type<IElectric> Electric => new Type<IElectric>();
        public static Type<IPsychic> Psychic => new Type<IPsychic>();
        public static Type<IIce> Ice => new Type<IIce>();
        public static Type<IDragon> Dragon => new Type<IDragon>();
        public static Type<IDark> Dark => new Type<IDark>();
        public static Type<IFairy> Fairy => new Type<IFairy>();

        private Type() {}
    }
}
