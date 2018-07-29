(function(){
    $(function() {
         
        var _personService = abp.services.app.person;
        var _$modal = $("#PersonCreateModal");
        var _$form = _$modal.find('form');

        //添加联系人功能

        _$form.find('button[type="submit"]').click(function(e) {
debugger;
            e.preventDefault();
            if (!_$form.valid()) {
                return;
            }
            var personEditDto = _$form.serializeFormToObject();//序列化表单为对象

            abp.ui.setBusy(_$modal);
               //约定大于配置 
            _personService.createOrUpdatePerson({personEditDto}).done(function() {
                _$modal.modal('hide');
                reloadPersonList();
            }).always(function() {
                abp.ui.clearBusy(_$modal);
            });

        });
        //刷新
        $("#RefreshButton").click(function () {
            reloadPersonList();

        })
        function reloadPersonList() {
            location.reload();
        }

        //删除
        $(".delete-person").click(function () {
            var personId = $(this).attr("data-person-id");
            var personName = $(this).attr("data-person-name");

            deletePerson(personId, personName);

        });
        function deletePerson(personId, personName) {
            abp.message.confirm("是否确定删除姓名为：" + personName + "联系人", function (isconfirm) {
                if (isconfirm) {
                    _personService.deletePerson({ id: personId }).done(function () {
                        reloadPersonList();
                    });
                }
            });
        }

        $(".edit-person").click(function (e) {
            e.preventDefault();
            var personId = $(this).attr("data-person-id");
            _personService.getPersonForEditById({ id: personId }).done(function (data) {
                $("input[name=Id]").val(data.person.id);
                $("input[name=Name]").val(data.person.name).parent().addClass("focused");
                $("input[name=EmailAddress]").val(data.person.emailAddress).parent().addClass("focused");
                $("input[name=Address]").val(data.person.address).parent().addClass("focused");
            });

        })

        $("#PersonCreateModal").on("hide.bs.hidden.bs.modal", function () {

            _$form[0].reset();
        })

     })

})()