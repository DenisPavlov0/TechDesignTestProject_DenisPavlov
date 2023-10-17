using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterClickAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Ссылка на компонент Animator объекта
        private Animator animator;
    
        // Метод, который вызывается при старте сцены
        private void Start()
        {
            // Получаем компонент Animator объекта
            animator = GetComponent<Animator>();
        }
    
        // Метод, который вызывается при нажатии на объект с коллайдером
        public void OnPointerDown(PointerEventData eventData)
        {
            // Запускаем анимацию нажатия
            animator.Play("zombie_walk_animation");
        }

        // Метод, который вызывается при отпускании объекта с коллайдером
        public void OnPointerUp(PointerEventData eventData)
        {
            // Запускаем анимацию отпускания
            animator.Play("Release");
        }
}
