/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package cl.duoc.ded5401.Solemne3.VentaDeTickets.Recursos;

/**
 * @date : 11-nov-2018
 * @author :Cristóbal Molina | Ivan Aviles C.
 * DED4501
 */
public class ArbolBalanceado {
    private NodoArbol raiz;

    public NodoArbol getRaiz() {
        return raiz;
    }

    public void setRaiz(NodoArbol raiz) {
        this.raiz = raiz;
    }
 
	//Si raiz es nula, inserta el nodo como raiz, sino, usa metodo de forma recursiva
    public void insertarNodo(Ticket objTicket) {
        if (raiz == null) {
            raiz = new NodoArbol(objTicket);
        } else {
            raiz = insertarNodo(raiz, objTicket);
        }   
    }
 
	//Si la raiz es null, sale sin hacer cambios, sino, invoca metodo de forma recursiva
    public void removerNodo(Ticket objTicket) {
        if (raiz == null) {
            return;
        } else {
            raiz = removerNodo(raiz, objTicket);
        }
    }
 
	//Si el objTicket del nuevo nodo, es menor al nodo padre, lo inserta a la izquierda (de estar
	//dicha posicion disponible, sino en el nodo a la derecha)
    private NodoArbol insertarNodo(NodoArbol raizSubArbol, Ticket objTicket) {
        if (objTicket.getNroTicket() < raizSubArbol.objTicket.getNroTicket()) {
            if (raizSubArbol.izquierda == null) {
                raizSubArbol.izquierda = new NodoArbol(objTicket);
            } else {
                raizSubArbol.izquierda = insertarNodo(raizSubArbol.izquierda, objTicket);
                //si la diferencia de altura del subarbol de la izquiera, con el subarbol de la derecha, es de 2 nodos, realiza una rotación de nodos.
				if (Math.abs(
                        altura(raizSubArbol.izquierda) - altura(raizSubArbol.derecha)) == 2) {
                    if (objTicket.getNroTicket() < raizSubArbol.izquierda.objTicket.getNroTicket()) {
                        raizSubArbol = rotacionIzqIzq(raizSubArbol);
                    } else {
                        raizSubArbol = rotacionIzqDere(raizSubArbol);
                    }
                }
            }
	//Si el objTicket del nuevo nodo, es mayor al nodo padre, lo inserta a la derecha (de estar
	//dicha posicion disponible, sino un nivel mas abajo en el arbol, usando el metodo recursivo)
        } else if (objTicket.getNroTicket() > raizSubArbol.objTicket.getNroTicket()) {
            if (raizSubArbol.derecha == null) {
                raizSubArbol.derecha = new NodoArbol(objTicket);
            } else {
                raizSubArbol.derecha = insertarNodo(raizSubArbol.derecha, objTicket);
                if (Math.abs(
                        altura(raizSubArbol.izquierda) - altura(raizSubArbol.derecha)) == 2) {
                    if (objTicket.getNroTicket() > raizSubArbol.derecha.objTicket.getNroTicket()) {
                        raizSubArbol = rotacionDerDer(raizSubArbol);
                    } else {
                        raizSubArbol = rotacionDereIzq(raizSubArbol);
                    }
                }
            }
        } else {
        }
 
        raizSubArbol.altura = Math.max(altura(raizSubArbol.izquierda), altura(raizSubArbol.derecha));
 
        return raizSubArbol;
    }
 
    private NodoArbol removerNodo(NodoArbol raizSubArbol, Ticket objTicket) {
        if (objTicket.getNroTicket() < raizSubArbol.objTicket.getNroTicket()) {
            if (raizSubArbol.izquierda == null) {
                return raizSubArbol;
            } else {
                raizSubArbol.izquierda = removerNodo(raizSubArbol.izquierda, objTicket);
                if (raizSubArbol.derecha != null && altura(raizSubArbol.derecha) - altura(raizSubArbol.izquierda) == 2) {
                    NodoArbol nodoArbolDerecha = raizSubArbol.derecha;
                    if (altura(nodoArbolDerecha.izquierda) <= altura(nodoArbolDerecha.derecha)) {
                        raizSubArbol = rotacionDerDer(raizSubArbol);
                    } else {
                        raizSubArbol = rotacionDereIzq(raizSubArbol);
                    }
                }
            }
        } else if (objTicket.getNroTicket() > raizSubArbol.objTicket.getNroTicket()) {
            if (raizSubArbol.derecha == null) {
                return raizSubArbol;
            } else {
                raizSubArbol.derecha = removerNodo(raizSubArbol.derecha, objTicket);
                if (raizSubArbol.izquierda != null && altura(raizSubArbol.izquierda) - altura(raizSubArbol.derecha) == 2) {
                    NodoArbol nodoArbolIzquierda = raizSubArbol.izquierda;
                    if (altura(nodoArbolIzquierda.izquierda) >= altura(nodoArbolIzquierda.derecha)) {
                        raizSubArbol = rotacionIzqIzq(raizSubArbol);
                    } else {
                        raizSubArbol = rotacionIzqDere(raizSubArbol);
                    }
                }
            }
        } else {
            if (raizSubArbol.izquierda == null || raizSubArbol.derecha == null) {
                if (raizSubArbol.izquierda == null) {
                    raizSubArbol = raizSubArbol.derecha;
                } else if (raizSubArbol.derecha == null) {
                    raizSubArbol = raizSubArbol.izquierda;
                } else {
                    raizSubArbol = null;
                }
            } else {
                NodoArbol inOrderSuccessor = nodoMenorValor(raizSubArbol.derecha);
                raizSubArbol.objTicket = inOrderSuccessor.objTicket;
                raizSubArbol.derecha = removerNodo(raizSubArbol.derecha, raizSubArbol.objTicket);
            }
        }
        if (raizSubArbol != null) {
            raizSubArbol.altura = Math.max(altura(raizSubArbol.izquierda),
                    altura(raizSubArbol.derecha));
        }
 
        return raizSubArbol;
    }
 
    private NodoArbol nodoMenorValor(NodoArbol nodoarbol) {
        NodoArbol actual = nodoarbol; 
        while (actual.izquierda != null) {
            actual = actual.izquierda;
        }
 
        return actual;
    }
 
    private NodoArbol rotacionIzqIzq(NodoArbol raizSubArbol) {
        NodoArbol nodoIzquierda = raizSubArbol.izquierda;
        raizSubArbol.izquierda = nodoIzquierda.derecha;
        nodoIzquierda.derecha = raizSubArbol;
        if (nodoIzquierda != null) {
            recalcularAltura(nodoIzquierda);
        }
        return nodoIzquierda;
    }
 
    private NodoArbol rotacionDerDer(NodoArbol raizSubArbol) {
        NodoArbol nodoDerecha = raizSubArbol.derecha;
        raizSubArbol.derecha = nodoDerecha.izquierda;
        nodoDerecha.izquierda = raizSubArbol;
        if (nodoDerecha != null) {
            recalcularAltura(nodoDerecha);
        }
        return nodoDerecha;
    }
 
    private NodoArbol rotacionIzqDere(NodoArbol raizSubArbol) {
        raizSubArbol.izquierda = rotacionDerDer(raizSubArbol.izquierda);
        return rotacionIzqIzq(raizSubArbol);
    }
 
    private NodoArbol rotacionDereIzq(NodoArbol raizSubArbol) {
        raizSubArbol.derecha = rotacionIzqIzq(raizSubArbol.derecha);
        return rotacionDerDer(raizSubArbol);
    }
 
    private void recalcularAltura(NodoArbol nodoArbol) {
        if (nodoArbol.izquierda != null) {
            nodoArbol.izquierda.altura = Math.max(altura(nodoArbol.izquierda.izquierda),
                    altura(nodoArbol.izquierda.derecha));
        }
        if (nodoArbol.derecha != null) {
            nodoArbol.derecha.altura = Math.max(altura(nodoArbol.derecha.izquierda),
                    altura(nodoArbol.derecha.derecha));
        }
 
    }
 
    private int altura(NodoArbol nodoArbol) {
        if (nodoArbol == null) {
            return 0;
        } else {
            return nodoArbol.altura + 1;
        }
    }
     
    public int factorEquilibrio(){
        if(this.raiz.derecha!=null && this.raiz.izquierda!=null){
            return (raiz.derecha.altura - raiz.izquierda.altura );
        }else if(this.raiz.derecha!=null && this.raiz.izquierda==null){
            return (this.raiz.derecha.altura - 0);
        }else if(this.raiz.derecha==null && this.raiz.izquierda!=null){
        return (0 - this.raiz.izquierda.altura);
        }else if(this.raiz.derecha==null && this.raiz.izquierda==null){
            return 0;
        }
        return -1;
    }
    
    public void recorrePreOrden(){
    
        auxPreorden(this.raiz);
        
    }
    
    public void auxPreorden(NodoArbol nodoArbol){
    
        if(nodoArbol == null){
            return;
        }else{
            System.out.println(nodoArbol.getObjTicket().toString());
            auxPreorden(nodoArbol.getIzquierda());
            auxPreorden(nodoArbol.getDerecha());
        }
        
    }
    public void recorreInOrden(){
    
        auxInorden(this.raiz);
        
    }
    
    public void auxInorden(NodoArbol nodoArbol){
    
        if(nodoArbol == null){
            return;
        }else{
            
            auxInorden(nodoArbol.getIzquierda());
            System.out.println(nodoArbol.getObjTicket().toString());
            auxInorden(nodoArbol.getDerecha());
        }
        
    }
    public void recorrePosOrden(){
    
        auxPosorden(this.raiz);
        
    }
    
    public void auxPosorden(NodoArbol nodoArbol){
    
        if(nodoArbol == null){
            return;
        }else{
            
            auxPosorden(nodoArbol.getIzquierda());
            auxPosorden(nodoArbol.getDerecha());
            System.out.println(nodoArbol.getObjTicket().toString());
        }
        
    }
    
    @Override
    public String toString() {
        return raiz.toString();
    }
    
    
}
