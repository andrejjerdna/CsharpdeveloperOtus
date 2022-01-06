using Solid.Abstractions;

namespace Solid
{
    /// <summary>
    /// Container configure for macros
    /// </summary>
    public sealed class ContainerConfigure : ContainerConfigureBase
    {
        private static ContainerConfigure _container;

        /// <summary>
        /// .ctor
        /// </summary>
        private ContainerConfigure()
        {
            RegisterTypes();
        }

        /// <summary>
        /// Get new instance the container and build of the container
        /// </summary>
        /// <returns></returns>
        public static ContainerConfigure GetContainer()
        {
            if (_container == null)
            {
                _container = new ContainerConfigure();
                _container.Build();
            }

            return _container;
        }

        /// <summary>
        /// Register types
        /// </summary>
        private void RegisterTypes()
        {
            RegisterType<QuestionGenerator, IQuestionGenerator>();
            RegisterType<GameManager, IGameManager>();
            RegisterType<ConsoleLogger, IConsoleLogger>();
            RegisterType<AnswerChecker, IAnswerChecker>();
            RegisterType<ConsoleReader, IConsoleReader>();
        }
    }
}
