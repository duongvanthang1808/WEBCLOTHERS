var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('.deletecart').off('click').on('click', function () {
            $.ajax({
                url: "/Cart/DeleteCart",
                data: { id: $(this).data('id') },
                dataType:'json',
                type: 'POST',
                success: function (result) {
                    if(result.status == true)
                    {
                        window.location.href = "/cart";
                    }
                }
            });
        });
    }
}

cart.init();