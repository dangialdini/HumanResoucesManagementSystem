using Domain.Models;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{

    public class EmployeeRepositoryStub : IEmployeeRepository
    {
        private Employee _employee;

        public EmployeeRepositoryStub(Employee employee)
        {
            _employee = employee;
        }

        public bool CacheUsed
        {
            get { throw new NotImplementedException(); }
        }

        public bool CachingEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public SharpRepository.Repository.Caching.ICachingStrategy<Domain.Models.Employee, int> CachingStrategy
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void ClearCache()
        {
            throw new NotImplementedException();
        }

        public SharpRepository.Repository.IRepositoryConventions Conventions
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(params int[] keys)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Collections.Generic.IEnumerable<int> keys)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public SharpRepository.Repository.IDisabledCache DisableCaching()
        {
            throw new NotImplementedException();
        }

        public Type EntityType
        {
            get { throw new NotImplementedException(); }
        }

        public bool Exists(int key)
        {
            throw new NotImplementedException();
        }

        public TResult Get<TResult>(int key, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Employee Get(int key)
        {
            return _employee;
        }

        #region Unused methods

        public int GetPrimaryKey(Domain.Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public Type KeyType
        {
            get { throw new NotImplementedException(); }
        }

        public string TraceInfo
        {
            get { throw new NotImplementedException(); }
        }

        public bool TryGet<TResult>(int key, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryGet(int key, out Domain.Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Collections.Generic.IEnumerable<Domain.Models.Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Domain.Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Add(System.Collections.Generic.IEnumerable<Domain.Models.Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(Domain.Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Update(System.Collections.Generic.IEnumerable<Domain.Models.Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Models.Employee entity)
        {

        }

        public SharpRepository.Repository.Transactions.IBatch<Domain.Models.Employee> BeginBatch()
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<Domain.Models.Employee> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TResult> GetAll<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Domain.Models.Employee> GetAll(SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Domain.Models.Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public SharpRepository.Repository.IRepositoryQueryable<TResult> Join<TJoinKey, TInner, TResult>(SharpRepository.Repository.IRepositoryQueryable<TInner> innerRepository, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TJoinKey>> outerKeySelector, System.Linq.Expressions.Expression<Func<TInner, TJoinKey>> innerKeySelector, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TInner, TResult>> resultSelector)
            where TInner : class
            where TResult : class
        {
            throw new NotImplementedException();
        }

        public bool Exists(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria)
        {
            throw new NotImplementedException();
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TResult Find<TResult>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Employee Find(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public TResult Find<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Employee Find(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TResult> FindAll<TResult>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Domain.Models.Employee> FindAll(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TResult> FindAll<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Domain.Models.Employee> FindAll(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public bool TryFind<TResult>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind<TResult>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions, out Domain.Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, out Domain.Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, SharpRepository.Repository.Queries.IQueryOptions<Domain.Models.Employee> queryOptions, out Domain.Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, out Domain.Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public float? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public float Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public float Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public int Count(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TResult> GroupBy<TGroupKey, TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> keySelector, System.Linq.Expressions.Expression<Func<System.Linq.IGrouping<TGroupKey, Domain.Models.Employee>, TResult>> resultSelector)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TResult> GroupBy<TGroupKey, TResult>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> keySelector, System.Linq.Expressions.Expression<Func<System.Linq.IGrouping<TGroupKey, Domain.Models.Employee>, TResult>> resultSelector)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TResult> GroupBy<TGroupKey, TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> keySelector, System.Linq.Expressions.Expression<Func<System.Linq.IGrouping<TGroupKey, Domain.Models.Employee>, TResult>> resultSelector)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IDictionary<TGroupKey, int> GroupCount<TGroupKey>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IDictionary<TGroupKey, int> GroupCount<TGroupKey>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IDictionary<TGroupKey, int> GroupCount<TGroupKey>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public long LongCount(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public TResult Max<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Max<TResult>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Max<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Min<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Min<TResult>(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Min<TResult>(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public float Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public float Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public double Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public double Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public long? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public long? Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public long? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public long Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public long Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public long Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public int? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public int? Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public int? Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public int Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public int Sum(SharpRepository.Repository.Specifications.ISpecification<Domain.Models.Employee> criteria, System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public int Sum(System.Linq.Expressions.Expression<Func<Domain.Models.Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        #endregion

    }



    public class EmployeeRepositorySpy : IEmployeeRepository
    {
        private Employee _employee;

        public EmployeeRepositorySpy(Employee employee)
        {
            _employee = employee;
        }

        public int NumTimesUpdateCalled { get; private set; }
        public int NumTimesGetCalled { get; private set; }
        public Employee EmployeeUpdated { get; private set; }

        public bool CacheUsed
        {
            get { throw new NotImplementedException(); }
        }

        public bool CachingEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public SharpRepository.Repository.Caching.ICachingStrategy<Employee, int> CachingStrategy
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void ClearCache()
        {
            throw new NotImplementedException();
        }

        public SharpRepository.Repository.IRepositoryConventions Conventions
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(params int[] keys)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<int> keys)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public SharpRepository.Repository.IDisabledCache DisableCaching()
        {
            throw new NotImplementedException();
        }

        public Type EntityType
        {
            get { throw new NotImplementedException(); }
        }

        public bool Exists(int key)
        {
            throw new NotImplementedException();
        }

        public TResult Get<TResult>(int key, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int key)
        {
            NumTimesGetCalled++;
            return _employee;
        }

        public int GetPrimaryKey(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Type KeyType
        {
            get { throw new NotImplementedException(); }
        }

        public string TraceInfo
        {
            get { throw new NotImplementedException(); }
        }

        public bool TryGet<TResult>(int key, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryGet(int key, out Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            this.EmployeeUpdated = entity;
            this.NumTimesUpdateCalled++;
        }

        public SharpRepository.Repository.Transactions.IBatch<Employee> BeginBatch()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> GetAll<TResult>(System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll(SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public SharpRepository.Repository.IRepositoryQueryable<TResult> Join<TJoinKey, TInner, TResult>(SharpRepository.Repository.IRepositoryQueryable<TInner> innerRepository, System.Linq.Expressions.Expression<Func<Employee, TJoinKey>> outerKeySelector, System.Linq.Expressions.Expression<Func<TInner, TJoinKey>> innerKeySelector, System.Linq.Expressions.Expression<Func<Employee, TInner, TResult>> resultSelector)
            where TInner : class
            where TResult : class
        {
            throw new NotImplementedException();
        }

        public bool Exists(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria)
        {
            throw new NotImplementedException();
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TResult Find<TResult>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public Employee Find(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public TResult Find<TResult>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public Employee Find(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> FindAll<TResult>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> FindAll(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> FindAll<TResult>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> FindAll(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions = null)
        {
            throw new NotImplementedException();
        }

        public bool TryFind<TResult>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind<TResult>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions, out Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, out Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind<TResult>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind<TResult>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector, out TResult entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, SharpRepository.Repository.Queries.IQueryOptions<Employee> queryOptions, out Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool TryFind(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, out Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public float? Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Average(System.Linq.Expressions.Expression<Func<Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public float Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public float Average(System.Linq.Expressions.Expression<Func<Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Average(System.Linq.Expressions.Expression<Func<Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Average(System.Linq.Expressions.Expression<Func<Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Average(System.Linq.Expressions.Expression<Func<Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public double Average(System.Linq.Expressions.Expression<Func<Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public int Count(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> GroupBy<TGroupKey, TResult>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> keySelector, System.Linq.Expressions.Expression<Func<IGrouping<TGroupKey, Employee>, TResult>> resultSelector)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> GroupBy<TGroupKey, TResult>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> keySelector, System.Linq.Expressions.Expression<Func<IGrouping<TGroupKey, Employee>, TResult>> resultSelector)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> GroupBy<TGroupKey, TResult>(System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> keySelector, System.Linq.Expressions.Expression<Func<IGrouping<TGroupKey, Employee>, TResult>> resultSelector)
        {
            throw new NotImplementedException();
        }

        public IDictionary<TGroupKey, int> GroupCount<TGroupKey>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public IDictionary<TGroupKey, int> GroupCount<TGroupKey>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public IDictionary<TGroupKey, int> GroupCount<TGroupKey>(System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(System.Linq.Expressions.Expression<Func<Employee, TGroupKey>> selector)
        {
            throw new NotImplementedException();
        }

        public long LongCount(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public TResult Max<TResult>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Max<TResult>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Max<TResult>(System.Linq.Expressions.Expression<Func<Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Min<TResult>(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Min<TResult>(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public TResult Min<TResult>(System.Linq.Expressions.Expression<Func<Employee, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float? Sum(System.Linq.Expressions.Expression<Func<Employee, float?>> selector)
        {
            throw new NotImplementedException();
        }

        public float Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public float Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public float Sum(System.Linq.Expressions.Expression<Func<Employee, float>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double? Sum(System.Linq.Expressions.Expression<Func<Employee, double?>> selector)
        {
            throw new NotImplementedException();
        }

        public double Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public double Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public double Sum(System.Linq.Expressions.Expression<Func<Employee, double>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal? Sum(System.Linq.Expressions.Expression<Func<Employee, decimal?>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public decimal Sum(System.Linq.Expressions.Expression<Func<Employee, decimal>> selector)
        {
            throw new NotImplementedException();
        }

        public long? Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public long? Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public long? Sum(System.Linq.Expressions.Expression<Func<Employee, long?>> selector)
        {
            throw new NotImplementedException();
        }

        public long Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public long Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public long Sum(System.Linq.Expressions.Expression<Func<Employee, long>> selector)
        {
            throw new NotImplementedException();
        }

        public int? Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public int? Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public int? Sum(System.Linq.Expressions.Expression<Func<Employee, int?>> selector)
        {
            throw new NotImplementedException();
        }

        public int Sum(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate, System.Linq.Expressions.Expression<Func<Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public int Sum(SharpRepository.Repository.Specifications.ISpecification<Employee> criteria, System.Linq.Expressions.Expression<Func<Employee, int>> selector)
        {
            throw new NotImplementedException();
        }

        public int Sum(System.Linq.Expressions.Expression<Func<Employee, int>> selector)
        {
            throw new NotImplementedException();
        }
    }
}
