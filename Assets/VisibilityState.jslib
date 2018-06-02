var VisibilityStatePlugin =
{
    // 初期化
    Initialize : function()
    {
        // 表示状態を返すように設定
        // https://developer.mozilla.org/ja/docs/Web/API/Document/hidden
        document.addEventListener("visibilitychange", function (e) { SendMessage("VisibilityStateChecker", "Send", document.hidden.toString()); });
        // 初期化時の状態を送信
        SendMessage("VisibilityStateChecker", "Send", document.hidden.toString());
    },
};

// LibraryManager.library内の関数がC#の空間へ露出
mergeInto(LibraryManager.library, VisibilityStatePlugin);
