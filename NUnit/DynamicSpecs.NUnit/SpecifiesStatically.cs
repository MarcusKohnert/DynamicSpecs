namespace DynamicSpecs.NUnit
{
    using DynamicSpecs.AutoFacItEasy;
    using DynamicSpecs.Core;

    using global::NUnit.Framework;

    [TestFixture]
    public class SpecifiesStatically : WorkflowSpecification
    {
        /// <summary>
        /// Gets or sets a container holding all registered types and can resolve mocks if no registration was made for a type.
        /// </summary>
        public TypeRegistry Registry { get; private set; }

        public SpecifiesStatically()
        {
            this.Registry = new TypeRegistry();
        }

        protected override IRegisterTypes GetTypeRegistry()
        {
            return this.Registry;
        }

        protected override IResolveTypes GetTypeResolver()
        {
            return this.Registry;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.Run();
        }

        [OneTimeTearDown]
        public void AfterSpecs()
        {
            this.OnSpecExecutionCompleted();
        }

        [TearDown]
        public void AfterThenStep()
        {
            this.OnThenIsCompleted();
        }
    }
}