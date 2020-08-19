using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace AzureZeng.JsonLocalization.DynamicLocalization
{
    public class DynamicBindObject
    {
        // object array format
        // propertyInfo, namespace, key
        internal readonly Collection<object[]> _bindProps = new Collection<object[]>();

        public object TargetObject { get; }

        public DynamicBindObject(object targetObject)
        {
            TargetObject = targetObject ?? throw new ArgumentNullException(nameof(targetObject));
        }

        public void RegisterNewProperty(string property, string namespaceName, string key)
        {
            if (!LocalizationData.ValidateName(namespaceName, true))throw new ArgumentException("Invalid namespace name.", nameof(namespaceName));
            if (!LocalizationData.ValidateName(key, false)) throw new ArgumentException("Invalid key name.", nameof(key));
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Value cannot be null or empty.", nameof(key));
            var p = TargetObject.GetType().GetProperty(property);
            if (p ==null)throw new ArgumentException(
                $"Cannot find property {property} in type {TargetObject.GetType().FullName}");
            _bindProps.Add(new object[]{p, namespaceName, key});
        }

        public void RegisterNewProperty(string property, string keyOrPath)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (string.IsNullOrEmpty(keyOrPath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(keyOrPath));
            if (!LocalizationData.ParsePathString(keyOrPath, out var namespaceName, out string key)) throw new ArgumentException("Invalid path or key.", nameof(keyOrPath));
            var p = TargetObject.GetType().GetProperty(property);
            if (p == null) throw new ArgumentException(
                $"Cannot find property {property} in type {TargetObject.GetType().FullName}");
            _bindProps.Add(new object[]{p, namespaceName, key});
        }

        public void RegisterNewProperty(PropertyInfo property, string namespaceName, string key)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (!LocalizationData.ValidateName(namespaceName, true)) throw new ArgumentException("Invalid namespace name.", nameof(namespaceName));
            if (!LocalizationData.ValidateName(key, false)) throw new ArgumentException("Invalid key name.", nameof(key));
            // validate?
            _bindProps.Add(new object[]{property, namespaceName, key});
        }

        public void RegisterNewProperty(PropertyInfo property, string keyOrPath)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (string.IsNullOrEmpty(keyOrPath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(keyOrPath));
            if (!LocalizationData.ParsePathString(keyOrPath, out var namespaceName, out string key)) throw new ArgumentException("Invalid path or key.", nameof(keyOrPath));
            // validate?
            _bindProps.Add(new object[] { property, namespaceName, key });
        }

        public void UnregisterProperty(string property)
        {
            object[] pi = null;
            foreach (var i in _bindProps)
            {
                if (!(i?[0] is PropertyInfo) || ((PropertyInfo) i[0]).Name != property) continue;
                pi = i;
                break;
            }
            if (pi != null) _bindProps.Remove(pi);
        }

        public void UnregisterProperty(PropertyInfo property)
        {
            object[] pi = null;
            foreach (var i in _bindProps)
            {
                if (!(i?[0] is PropertyInfo) || (PropertyInfo)i[0] != property) continue;
                pi = i;
                break;
            }
            if (pi != null) _bindProps.Remove(pi);
        }
    }
}
