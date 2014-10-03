namespace Entidades.Mapping
{
    public abstract class Entity<TEntity, TDataContract>
        where TEntity : Entity<TEntity, TDataContract>, new()
        where TDataContract : class, new()
    {
        public static explicit operator TDataContract(Entity<TEntity, TDataContract> entity)
        {
            return ConvertType<TEntity, TDataContract>((TEntity)entity, new DataContractMappingPolicy());
        }

        public static explicit operator Entity<TEntity, TDataContract>(TDataContract dataContract)
        {
            return ConvertType<TDataContract, TEntity>(dataContract, new EntityMappingPolicy());
        }

        private static TOutput ConvertType<TInput, TOutput>(TInput inputInstance, IMappingPolicy mappingPolicy) 
            where TOutput : class, new()
        {
            if (inputInstance == null)
                {
                    return null;
                  }

            PropertyMapperSequence<TInput, TOutput> mapperSequence =
                PropertyMapperFactory.GetPropertyMapperSequence<TInput, TOutput>(mappingPolicy);

            TOutput outputInstance = new TOutput();

            mapperSequence.MapProperties(inputInstance, outputInstance);

            return outputInstance;
        }
    }
}
