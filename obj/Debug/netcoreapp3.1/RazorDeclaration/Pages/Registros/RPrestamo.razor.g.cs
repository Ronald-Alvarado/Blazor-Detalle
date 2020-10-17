#pragma checksum "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\Pages\Registros\RPrestamo.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "061513b083565a44f0d11225de1fd129f6ebe508"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Blazor_Detalle.Pages.Registros
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Blazor_Detalle;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Blazor_Detalle.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\Pages\Registros\RPrestamo.razor"
using BLL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\Pages\Registros\RPrestamo.razor"
using Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Prestamo")]
    public partial class RPrestamo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 82 "C:\Users\RONALD\source\BlazorApp\Blazor-Detalle\Pages\Registros\RPrestamo.razor"
      
    private Prestamo prestamo = new Prestamo();
    List<Persona> ListaPersonas = new List<Persona>();
    protected override void OnInitialized()
    {
        Nuevo();
    }

    public float Balance { get; set;}
    
    private void ObtenerBalance()
    {
        Persona persona = PersonaBLL.Buscar(prestamo.PersonaId);

        if (persona != null)
        {
            prestamo.PersonaId = persona.PersonaId;
            prestamo.Balance = persona.Balance;
        }
        
        Balance = prestamo.Balance;
    }

    private void CalcularMonto(){
        prestamo.Balance = Balance + prestamo.Monto;
    }

    private void Nuevo()
    {
        prestamo = new Prestamo();
        ListaPersonas = PersonaBLL.GetList(c => true);
    }

    private void Guardar()
    {
        if(prestamo.PrestamoId == 0){    
            if(ExisteCliente()){
                Toast.ShowError("Este Cliente ya tiene un prestamo");
                return;
            }
        }

        Persona persona = PersonaBLL.Buscar(prestamo.PersonaId);
        bool guardado;

        PrestamoBLL.AnadirBalance(prestamo, persona);

        guardado = PrestamoBLL.Guardar(prestamo);

        if (guardado)
        {
            Nuevo();
            Toast.ShowSuccess("Se ha Guardado Exitosamente");
        }
        else
            Toast.ShowError("Error, no se pudo Guardar");
    }

    private bool ExisteCliente(){
        Persona persona = PersonaBLL.Buscar(prestamo.PersonaId);

        if(persona.Balance > 0){
            return true;
        }else{
            return false;
        }

    }

    private void Buscar()
    {
         if (prestamo.PrestamoId > 0)
         {                        
            var encontrado = PrestamoBLL.Buscar(prestamo.PrestamoId);

            if(prestamo.PersonaId == 0)
            {
                Toast.ShowWarning("El cliente de este prestamo ya no existe");
                return;
            }else{

                if (encontrado != null){
                    prestamo = encontrado;
			    }else{
                    Toast.ShowWarning("No se pudo localizar el Prestamo indicado");
			    }
            }
        }       
    }

    private void Eliminar()
    {
        Persona persona = PersonaBLL.Buscar(prestamo.PersonaId);
        bool elimino;

        PrestamoBLL.QuitarBalance(persona);

        elimino = PrestamoBLL.Eliminar(prestamo.PrestamoId);

        if (elimino)
        {
            Nuevo();
            Toast.ShowSuccess("Se ha Eliminado Exitosamente");
        }
        else
            Toast.ShowError("No se pudo localizar el Prestamo indicado");     
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService Toast { get; set; }
    }
}
#pragma warning restore 1591
