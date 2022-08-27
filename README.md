# Kogane Game Object Component Extension Methods

GameObject、Component 型の拡張メソッド

## GameObject

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        // GetComponent します
        // コンポーネントがアタッチされていない場合は AddComponent してから取得します
        var rigidbody = gameObject.GetOrAddComponent<Rigidbody>();

        // すべての子オブジェクトを取得します
        var children1 = gameObject.GetChildren();

        // すべての子オブジェクトを取得します（非アクティブも対象）
        var children2 = gameObject.GetChildren( true );

        // 自分自身を含まない GetComponentInChildren を実行します
        var collider1 = gameObject.GetComponentInChildrenWithoutSelf<BoxCollider>();
        
        // 自分自身を含まない GetComponentInChildren を実行します（非アクティブも対象）
        var collider2 = gameObject.GetComponentInChildrenWithoutSelf<BoxCollider>( true );
        
        // 自分自身を含まない GetComponentsInChildren を実行します
        var colliders1 = gameObject.GetComponentsInChildrenWithoutSelf<BoxCollider>();
        
        // 自分自身を含まない GetComponentsInChildren を実行します（非アクティブも対象）
        var colliders2 = gameObject.GetComponentsInChildrenWithoutSelf<BoxCollider>( true );

        // 指定されたコンポーネントを Destroy します
        gameObject.RemoveComponent<Rigidbody>();
        
        // 指定されたコンポーネントをすべて Destroy します
        gameObject.RemoveComponents<Rigidbody>();
        
        // 指定されたコンポーネントを DestroyImmediate します
        gameObject.RemoveComponentImmediate<Rigidbody>();
        
        // 指定されたコンポーネントをすべて DestroyImmediate します
        gameObject.RemoveComponentsImmediate<Rigidbody>();

        // 指定されたコンポーネントを持っている場合 true
        if ( gameObject.HasComponent<BoxCollider>() )
        {
        }

        // 深い階層まで子オブジェクトを名前の完全一致で検索します
        var button1 = gameObject.FindDeep( "Button" );
        
        // 深い階層まで子オブジェクトを名前の完全一致で検索します（非アクティブも対象）
        var button2 = gameObject.FindDeep( "Button", true );

        // Transform.Find します
        var image1 = gameObject.Find( "Icon" );

        // Transform.Find して結果を GameObject 型で取得します
        var image2 = gameObject.FindGameObject( "Icon" );

        // 親オブジェクトが存在する場合 true
        if ( gameObject.HasParent() )
        {
        }

        // 親オブジェクトを取得
        var parent = gameObject.GetParent();

        var newParent          = new GameObject();
        var newParentTransform = newParent.transform;

        // 親オブジェクトを GameObject 型で設定
        gameObject.SetParent( newParent );
        
        // 親オブジェクトを Component 型で設定
        gameObject.SetParent( newParentTransform );
        
        // 子オブジェクトが存在する場合 true
        if ( gameObject.HasChild() )
        {
        }

        // Transform.GetChild します
        var child = gameObject.GetChild( 0 );

        // ルートとなるゲームオブジェクトを取得します
        var root = gameObject.GetRoot();

        // レイヤーを設定します
        gameObject.SetLayer( 5 );
        
        // レイヤーをレイヤー名で設定します
        gameObject.SetLayer( "UI" );
        
        // 自分自身を含めたすべての子オブジェクトのレイヤーを設定します
        gameObject.SetLayerRecursively( 5 );

        // 自分自身を含めたすべての子オブジェクトのレイヤーをレイヤー名で設定します
        gameObject.SetLayerRecursively( "UI" );

        // DontDestroyOnLoad を適用します
        gameObject.DontDestroyOnLoad();

        // Destroy します
        gameObject.Destroy();

        // DestroyImmediate します
        gameObject.DestroyImmediate();

        // Hierarchy におけるパスを取得します
        Debug.Log( gameObject.GetHierarchyPath() );

        // アクティブかどうかを設定します
        // ゲームオブジェクトが null なら何もしません
        gameObject.SetActiveIfNotNull( true );

        // 指定されたアクティブと逆の状態にしてから指定されたアクティブになります
        gameObject.ToggleActive( true );
        
        // 指定されたアクティブと逆の状態にしてから指定されたアクティブになります
        // ゲームオブジェクトが null なら何もしません
        gameObject.ToggleActiveIfNotNull( true );
    }
}
```

## Component

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        // GetComponent します
        // コンポーネントがアタッチされていない場合は AddComponent してから取得します
        var rigidbody = this.GetOrAddComponent<Rigidbody>();

        // すべての子オブジェクトを取得します
        var children1 = this.GetChildren();

        // すべての子オブジェクトを取得します（非アクティブも対象）
        var children2 = this.GetChildren( true );

        // 自分自身を含まない GetComponentInChildren を実行します
        var collider1 = this.GetComponentInChildrenWithoutSelf<BoxCollider>();
        
        // 自分自身を含まない GetComponentInChildren を実行します（非アクティブも対象）
        var collider2 = this.GetComponentInChildrenWithoutSelf<BoxCollider>( true );
        
        // 自分自身を含まない GetComponentsInChildren を実行します
        var colliders1 = this.GetComponentsInChildrenWithoutSelf<BoxCollider>();
        
        // 自分自身を含まない GetComponentsInChildren を実行します（非アクティブも対象）
        var colliders2 = this.GetComponentsInChildrenWithoutSelf<BoxCollider>( true );

        // 指定されたコンポーネントを Destroy します
        this.RemoveComponent<Rigidbody>();
        
        // 指定されたコンポーネントをすべて Destroy します
        this.RemoveComponents<Rigidbody>();
        
        // 指定されたコンポーネントを DestroyImmediate します
        this.RemoveComponentImmediate<Rigidbody>();
        
        // 指定されたコンポーネントをすべて DestroyImmediate します
        this.RemoveComponentsImmediate<Rigidbody>();

        // 指定されたコンポーネントを持っている場合 true
        if ( this.HasComponent<BoxCollider>() )
        {
        }

        // 深い階層まで子オブジェクトを名前の完全一致で検索します
        var button1 = this.FindDeep( "Button" );
        
        // 深い階層まで子オブジェクトを名前の完全一致で検索します（非アクティブも対象）
        var button2 = this.FindDeep( "Button", true );

        // Transform.Find します
        var image1 = this.Find( "Icon" );

        // Transform.Find して結果を this 型で取得します
        var image2 = this.FindGameObject( "Icon" );

        // 親オブジェクトが存在する場合 true
        if ( this.HasParent() )
        {
        }

        // 親オブジェクトを取得
        var parent = this.GetParent();

        var newParent          = new GameObject();
        var newParentTransform = newParent.transform;

        // 親オブジェクトを GameObject 型で設定
        this.SetParent( newParent );
        
        // 親オブジェクトを Component 型で設定
        this.SetParent( newParentTransform );
        
        // 子オブジェクトが存在する場合 true
        if ( this.HasChild() )
        {
        }

        // Transform.GetChild します
        var child = this.GetChild( 0 );

        // ルートとなるゲームオブジェクトを取得します
        var root = this.GetRoot();

        // レイヤーを設定します
        this.SetLayer( 5 );
        
        // レイヤーをレイヤー名で設定します
        this.SetLayer( "UI" );
        
        // 自分自身を含めたすべての子オブジェクトのレイヤーを設定します
        this.SetLayerRecursively( 5 );

        // 自分自身を含めたすべての子オブジェクトのレイヤーをレイヤー名で設定します
        this.SetLayerRecursively( "UI" );
        
        // Destroy します
        this.Destroy();

        // DestroyImmediate します
        this.DestroyImmediate();

        // Hierarchy におけるパスを取得します
        Debug.Log( this.GetHierarchyPath() );

        // アクティブかどうかを設定します
        // null なら何もしません
        this.SetActiveIfNotNull( true );

        // 指定されたアクティブと逆の状態にしてから指定されたアクティブになります
        this.ToggleActive( true );
        
        // 指定されたアクティブと逆の状態にしてから指定されたアクティブになります
        // null なら何もしません
        this.ToggleActiveIfNotNull( true );

        // AddComponent します
        this.AddComponent<Rigidbody>();

        // SetActive します
        this.SetActive( true );

        // 自分自身が削除済みの場合 true を取得します
        if ( this.HasBeenDestroyed() )
        {
        }

        // このコンポーネントがアタッチされているゲームオブジェクトを Destroy します
        this.DestroyGameObject();

        // このコンポーネントがアタッチされているゲームオブジェクトを Destroy します
        // null なら何もしません
        this.DestroyGameObjectIfNotNull();
    }
}
```

## 特徴

### gameObject プロパティへのアクセスを省略できる

```cs
boxCollider.gameObject.SetActive( true );
boxCollider.gameObject.AddComponent<Rigidbody>();
```

通常では上記のように gameObject プロパティを介して関数にアクセスする必要があるコードを

```cs
boxCollider.SetActive( true );
boxCollider.AddComponent<Rigidbody>();
```

このように記述できるようになります
