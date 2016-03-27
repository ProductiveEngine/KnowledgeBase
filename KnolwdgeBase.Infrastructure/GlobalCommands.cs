using Prism.Commands;

namespace KnolwdgeBase.Infrastructure
{
    public static class GlobalCommands
    {
        public static CompositeCommand SaveAllCommand = new CompositeCommand();
        public static CompositeCommand NavigateCommand = new CompositeCommand();
    }
}
