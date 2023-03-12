using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pather.CSharp.PathElements;

namespace Pather.CSharp
{
    public interface IResolver
    {
        IList<IPathElementFactory> PathElementFactories { get; set; }

        IList<IPathElement> CreatePath(string path);
        /// <summary>
        /// Returns the object defined by the path elements.
        /// Any access exception (e.g. NullReference) is propagated.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pathElements"></param>
        /// <returns></returns>
        object Resolve(object target, IList<IPathElement> pathElements);

        /// <summary>
        /// Returns the object defined by the path.
        /// Any access exception (e.g. NullReference) is propagated.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        object Resolve(object target, string path);

        /// <summary>
        /// Returns null if any object in the path is null
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pathElements"></param>
        /// <returns></returns>
        object ResolveSafe(object target, IList<IPathElement> pathElements);

        /// <summary>
        /// Returns null if any object in the path is null
        /// </summary>
        /// <param name="target"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        object ResolveSafe(object target, string path);

        /// <summary>
        /// extract field path by a  lambda expression<br/>
        /// usage example: ExtractPath(()=>student.subjects[0].score) returns "student.subjects[0].score"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        string ExtractPath<T>(Expression<Func<T>> lambdaExpression);
    }
}