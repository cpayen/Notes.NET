using Core.Data;
using Core.Data.Repositories;
using Data.FileSystem.Repositories;

namespace Data.FileSystem
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBSettings _settings;

        public UnitOfWork(DBSettings settings)
        {
            _settings = settings;
        }

        private IReadContentRepository _readContentRepository;

        public IReadContentRepository ReadContentRepository
        {
            get
            {
                if (_readContentRepository == null)
                {
                    _readContentRepository = new ReadContentRepository(_settings);
                }
                return _readContentRepository;
            }
        }
    }
}
