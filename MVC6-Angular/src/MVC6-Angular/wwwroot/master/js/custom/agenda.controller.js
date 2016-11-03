
// To run this code, edit file index.html or index.jade and change
// html data-ng-app attribute from angle to myAppName
// ----------------------------------------------------------------------

(function() {
    'use strict';
    angular.module('app.agenda').controller('AgendaController', [
	'$scope',
	'$interval',
	'$stateParams',
	'$location',
	'DTOptionsBuilder',
	'DTColumnDefBuilder',
	'SweetAlert',
    '$uibModal',
	function ($scope,
		$interval,
		$stateParams,
		$location,
		DTOptionsBuilder,
		DTColumnDefBuilder,
		SweetAlert,
        $uibModal) {

	    this.dtOptions = DTOptionsBuilder
            .newOptions()
            .withOption('bLengthChange', false)
            .withOption('bInfo', false)
            .withOption('processing', true)
            .withPaginationType('full_numbers');

	    this.dtColumnDefs = [
			DTColumnDefBuilder
				.newColumnDef(0)
				.withOption('bSearchable', false)
				.notVisible()
				.notSortable(),
	        DTColumnDefBuilder
	        	.newColumnDef(1)
	        	.notSortable()
	    ];

	    $scope.urlBase = '/#!/usuarios-mobile';

	    // Context
	    $scope.agendas = [];

	    ModalInstanceCtrl.$inject = ['$scope', '$uibModal', 'DTOptionsBuilder', 'DTColumnDefBuilder'];
	    function ModalInstanceCtrl($scope, $uibModal, DTOptionsBuilder, DTColumnDefBuilder) {

	        $scope.dtOptionsTelefone = DTOptionsBuilder
               .newOptions()
               .withOption('bLengthChange', false)
               .withOption('bInfo', false)
                .withOption('bFilter', false)
               .withOption('processing', true)
               .withPaginationType('full_numbers');

	        $scope.dtColumnDefsTelefone = [
                DTColumnDefBuilder
                    .newColumnDef(0)
                    .withOption('bSearchable', false)
                    .notVisible()
                    .notSortable(),
                DTColumnDefBuilder
                    .newColumnDef(1)
                    .notSortable()
	        ];

	        $scope.telefones = [];

	        $scope.open = function ($event) {
	            $event.preventDefault();
	            $event.stopPropagation();

	            $scope.opened = true;
	        };

	        $scope.ok = function (objeto) {

	            if (objeto == undefined || objeto.name == undefined || objeto.name == '') {
	                SweetAlert.swal('Erro!', 'existem campos não preenchidos', 'error');
	                return;
	            }
	            var model = objeto;

	            if ($scope.showInputs) {
	                $scope.showInputs = false;
	                $scope.telefones.push(objeto);
	                $scope.telefone = {};
	            } else
                    // salva a agenda
	                $scope.$close();


	            //// Redirect after save
	            //model.$save(function (response) {
	            //    console.log(response);
	            //    $scope.$close(response);
	            //}, function (errorResponse) {
	            //    SweetAlert.swal('Erro!', errorResponse.data.message, errorResponse.data.type);
	            //});
	        };

	        $scope.cancel = function () {

	            if ($scope.showInputs) {
	                $scope.showInputs = false;
	            } else
	                $scope.$dismiss();
	        };


	        $scope.addItem = function (item) {
	            $scope.showInputs = true;
	        };
	    }

	    $scope.addItem = function (item) {
	        // var novoUsuario = {
	        // 	name: null,
	        // 	email: null
	        // };
	        // $scope.usuariosMobile.unshift(novoUsuario);				
	        var modalInstance = $uibModal.open({
	            templateUrl: 'modalInserir.html',
	            controller: ModalInstanceCtrl,
	            size: 'md'
	        });

	        var state = $('#modal-state');
	        modalInstance.result.then(function () {
	            state.text('Modal dismissed with OK status');
	        }, function () {
	            state.text('Modal dismissed with Cancel status');
	        });
	    };

	    $scope.visualizar = function (item) {
	        window.location = '/#!/veiculos/' + item._id;
	    };

	    $scope.deleteConfirm = function (index) {
	        SweetAlert.swal({
	            title: 'Você tem certeza?',
	            text: 'Após deletado não vai ser mais possível acessar o registro!',
	            type: 'warning',
	            showCancelButton: true,
	            confirmButtonColor: '#DD6B55',
	            confirmButtonText: 'Sim',
	            cancelButtonText: 'Não',
	            closeOnConfirm: false,
	            closeOnCancel: false
	        }, function (isConfirm) {
	            if (isConfirm) {
	                var usuarioMobile = $scope.leiloes[index];
	                if (usuarioMobile) {
	                    usuarioMobile.$remove(function (response) {
	                        if (response) {
	                            $scope.leiloes = _.without($scope.leiloes, usuarioMobile);

	                            SweetAlert.swal('Deletado!', 'O registro foi deletado.', 'success');
	                        }
	                    }, function (errorResponse) {
	                        $scope.error = errorResponse.data.message;
	                        SweetAlert.swal('Erro!', errorResponse.data.message, errorResponse.data.type);
	                    });
	                }

	            } else {
	                SweetAlert.swal('Cancelado', 'O registro não foi removido :)', 'error');
	            }
	        });
	    };
	}
    ]);
})();
