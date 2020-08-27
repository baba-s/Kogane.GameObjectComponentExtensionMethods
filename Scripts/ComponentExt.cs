using JetBrains.Annotations;
using System.Linq;
using UnityEngine;

namespace Kogane
{
	/// <summary>
	/// Component 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ComponentExt
	{
		/// <summary>
		/// GetComponent します。コンポーネントがアタッチされていない場合は AddComponent してから返します
		/// </summary>
		[NotNull]
		public static T GetOrAddComponent<T>( this Component self ) where T : Component
		{
			var result = self.GetComponent<T>();

			if ( result == null )
			{
				result = self.AddComponent<T>();
			}

			return result;
		}

		/// <summary>
		/// すべての子オブジェクトを返します
		/// </summary>
		public static GameObject[] GetChildren( this Component self )
		{
			return self.GetChildren( false );
		}

		/// <summary>
		/// すべての子オブジェクトを返します
		/// </summary>
		public static GameObject[] GetChildren( this Component self, bool includeInactive )
		{
			return self
					.GetComponentsInChildren<Transform>( includeInactive )
					.Where( x => x != self.transform )
					.Select( x => x.gameObject )
					.ToArray()
				;
		}

		/// <summary>
		/// 自分自身を含まない GetComponentInChildren を実行します
		/// </summary>
		[CanBeNull]
		public static T GetComponentInChildrenWithoutSelf<T>( this Component self ) where T : Component
		{
			return self.GetComponentInChildrenWithoutSelf<T>( false );
		}

		/// <summary>
		/// 自分自身を含まない GetComponentInChildren を実行します
		/// </summary>
		[CanBeNull]
		public static T GetComponentInChildrenWithoutSelf<T>( this Component self, bool includeInactive ) where T : Component
		{
			return self
					.GetComponentsInChildrenWithoutSelf<T>( includeInactive )
					.FirstOrDefault()
				;
		}

		/// <summary>
		/// 自分自身を含まない GetComponentsInChildren を実行します
		/// </summary>
		public static T[] GetComponentsInChildrenWithoutSelf<T>( this Component self ) where T : Component
		{
			return self.GetComponentsInChildrenWithoutSelf<T>( false );
		}

		/// <summary>
		/// 自分自身を含まない GetComponentsInChildren を実行します
		/// </summary>
		public static T[] GetComponentsInChildrenWithoutSelf<T>( this Component self, bool includeInactive ) where T : Component
		{
			return self
					.GetComponentsInChildren<T>( includeInactive )
					.Where( x => self != x.gameObject )
					.ToArray()
				;
		}

		/// <summary>
		/// 指定されたコンポーネントを Destroy します
		/// </summary>
		public static void RemoveComponent<T>( this Component self ) where T : Object
		{
			Object.Destroy( self.GetComponent<T>() );
		}

		/// <summary>
		/// 指定されたすべてのコンポーネントを Destroy します
		/// </summary>
		public static void RemoveComponents<T>( this Component self ) where T : Object
		{
			foreach ( var component in self.GetComponents<T>() )
			{
				Object.Destroy( component );
			}
		}

		/// <summary>
		/// 指定されたコンポーネントを DestroyImmediate します
		/// </summary>
		public static void RemoveComponentImmediate<T>( this Component self ) where T : Object
		{
			Object.DestroyImmediate( self.GetComponent<T>() );
		}

		/// <summary>
		/// 指定されたすべてのコンポーネントを DestroyImmediate します
		/// </summary>
		public static void RemoveComponentsImmediate<T>( this Component self ) where T : Object
		{
			foreach ( var component in self.GetComponents<T>() )
			{
				Object.DestroyImmediate( component );
			}
		}

		/// <summary>
		/// 指定されたコンポーネントを持っている場合 true を返します
		/// </summary>
		public static bool HasComponent<T>( this Component self )
		{
			return self.GetComponent<T>() != null;
		}

		/// <summary>
		/// 深い階層まで子オブジェクトを名前の完全一致で検索します
		/// </summary>
		[CanBeNull]
		public static GameObject FindDeep( this Component self, string name )
		{
			return self.FindDeep( name, false );
		}

		/// <summary>
		/// 深い階層まで子オブジェクトを名前の完全一致で検索します
		/// </summary>
		[CanBeNull]
		public static GameObject FindDeep
		(
			this Component self,
			string         name,
			bool           includeInactive
		)
		{
			var children = self.GetComponentsInChildren<Transform>( includeInactive );

			for ( var i = 0; i < children.Length; i++ )
			{
				var child = children[ i ];

				if ( child.name == name )
				{
					return child.gameObject;
				}
			}

			return null;
		}

		/// <summary>
		/// Transform.Find します
		/// </summary>
		[CanBeNull]
		public static Transform Find( this Component self, string name )
		{
			return self.transform.Find( name );
		}

		/// <summary>
		/// Transform.Find して結果を GameObject 型で返します
		/// </summary>
		[CanBeNull]
		public static GameObject FindGameObject( this Component self, string name )
		{
			var result = self.transform.Find( name );
			return result != null ? result.gameObject : null;
		}

		/// <summary>
		/// 親オブジェクトが存在する場合 true を返します
		/// </summary>
		public static bool HasParent( this Component self )
		{
			return self.transform.parent != null;
		}

		/// <summary>
		/// 親オブジェクトを返します
		/// </summary>
		[CanBeNull]
		public static Transform GetParent( this Component self )
		{
			return self.transform.parent;
		}

		/// <summary>
		/// 親オブジェクトを設定します
		/// </summary>
		public static void SetParent( this Component self, Component parent )
		{
			self.transform.SetParent( parent != null ? parent.transform : null );
		}

		/// <summary>
		/// 親オブジェクトを設定します
		/// </summary>
		public static void SetParent( this Component self, GameObject parent )
		{
			self.transform.SetParent( parent != null ? parent.transform : null );
		}

		/// <summary>
		/// 子オブジェクトが存在する場合 true を返します
		/// </summary>
		public static bool HasChild( this Component self )
		{
			return 0 < self.transform.childCount;
		}

		/// <summary>
		/// 指定されたインデックスに存在する子オブジェクトを返します
		/// </summary>
		[CanBeNull]
		public static Transform GetChild( this Component self, int index )
		{
			return self.transform.GetChild( index );
		}

		/// <summary>
		/// ルートとなるオブジェクトを返します
		/// </summary>
		[NotNull]
		public static Transform GetRoot( this Component self )
		{
			return self.transform.root;
		}

		/// <summary>
		/// レイヤーを設定します
		/// </summary>
		public static void SetLayer( this Component self, int layer )
		{
			self.gameObject.layer = layer;
		}

		/// <summary>
		/// レイヤーをレイヤー名で設定します
		/// </summary>
		public static void SetLayer( this Component self, string layerName )
		{
			self.gameObject.layer = LayerMask.NameToLayer( layerName );
		}

		/// <summary>
		/// 自分自身を含めたすべての子オブジェクトのレイヤーを設定します
		/// </summary>
		public static void SetLayerRecursively( this Component self, int layer )
		{
			self.gameObject.layer = layer;

			foreach ( Transform child in self.transform )
			{
				SetLayerRecursively( child, layer );
			}
		}

		/// <summary>
		/// 自分自身を含めたすべての子オブジェクトのレイヤーをレイヤー名で設定します
		/// </summary>
		public static void SetLayerRecursively( this Component self, string layerName )
		{
			self.SetLayerRecursively( LayerMask.NameToLayer( layerName ) );
		}

		/// <summary>
		/// 自分自身を Destroy します
		/// </summary>
		public static void Destroy( this Component self )
		{
			Object.Destroy( self );
		}

		/// <summary>
		/// 自分自身を DestroyImmediate します
		/// </summary>
		public static void DestroyImmediate( this Component self )
		{
			Object.DestroyImmediate( self );
		}

		/// <summary>
		/// Hierarchy におけるパスを返します
		/// </summary>
		public static string GetHierarchyPath( this Component self )
		{
			var path   = self.name;
			var parent = self.transform.parent;

			while ( parent != null )
			{
				path   = parent.name + "/" + path;
				parent = parent.parent;
			}

			return path;
		}

		/// <summary>
		/// アクティブかどうかを設定します
		/// </summary>
		public static void SetActiveIfNotNull( this Component self, bool isActive )
		{
			if ( self == null ) return;
			self.SetActive( isActive );
		}

		/// <summary>
		/// 指定された状態と逆の状態にしてから指定された状態になります
		/// </summary>
		public static void ToggleActive( this Component self, bool isActive )
		{
			self.SetActive( !isActive );
			self.SetActive( isActive );
		}

		/// <summary>
		/// 指定された状態と逆の状態にしてから指定された状態になります
		/// </summary>
		public static void ToggleActiveIfNotNull( this Component self, bool isActive )
		{
			if ( self == null ) return;
			self.ToggleActive( isActive );
		}

		/// <summary>
		/// AddComponent します
		/// </summary>
		[NotNull]
		public static T AddComponent<T>( this Component self ) where T : Component
		{
			return self.gameObject.AddComponent<T>();
		}

		/// <summary>
		/// SetActive します
		/// </summary>
		public static void SetActive( this Component self, bool value )
		{
			self.gameObject.SetActive( value );
		}

		/// <summary>
		/// 自分自身が削除済みの場合 true を返します
		/// </summary>
		public static bool HasBeenDestroyed( this Component self )
		{
			return self == null || self.gameObject == null;
		}
	}
}