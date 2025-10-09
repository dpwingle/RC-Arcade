using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using ConfigSystem.Preset;
using ConfigSystem;
using ConfigSystem.Data;
using ConfigSystem.Simpl;
using ConfigSystem.Manager;

namespace UserModule_CONFIG_SYSTEM_V3_0_0_CONFIG_BLOCKSERIAL_AVISPL
{
    public class UserModuleClass_CONFIG_SYSTEM_V3_0_0_CONFIG_BLOCKSERIAL_AVISPL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.StringInput> VALUE;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> VALUEFB;
        StringParameter MANAGERNAME;
        StringParameter VALUENAME;
        ConfigSystem.Simpl.ConfigValue THECONFIG;
        private void MODULEINITIALIZE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 111;
            THECONFIG . Register ( MANAGERNAME  .ToString(), VALUENAME  .ToString(), (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 113;
            // RegisterEvent( THECONFIG , ONVALUECHANGED , ONVALUECHANGEDHANDLER ) 
            try { g_criticalSection.Enter(); THECONFIG .OnValueChanged  += ONVALUECHANGEDHANDLER; } finally { g_criticalSection.Leave(); }
            ; 
            
            }
            
        object VALUE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 122;
                THECONFIG . SetBlockSerial ( (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), VALUE[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] .ToString()) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void ONVALUECHANGEDHANDLER ( object __sender__ /*ConfigSystem.Simpl.ConfigValue SENDER */, ConfigSystem.Data.ConfigEventArgs ARGS ) 
        { 
        ConfigValue  SENDER  = (ConfigValue )__sender__;
        try
        {
            SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
            
            __context__.SourceCodeLine = 127;
            MakeString ( VALUEFB [ ARGS.ValueIndex] , "{0}", ARGS . ValueAsSerial ( ) ) ; 
            
            
        }
        finally { ObjectFinallyHandler(); }
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 136;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 138;
            MODULEINITIALIZE (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        VALUE = new InOutArray<StringInput>( 32, this );
        for( uint i = 0; i < 32; i++ )
        {
            VALUE[i+1] = new Crestron.Logos.SplusObjects.StringInput( VALUE__AnalogSerialInput__ + i, VALUE__AnalogSerialInput__, 254, this );
            m_StringInputList.Add( VALUE__AnalogSerialInput__ + i, VALUE[i+1] );
        }
        
        VALUEFB = new InOutArray<StringOutput>( 32, this );
        for( uint i = 0; i < 32; i++ )
        {
            VALUEFB[i+1] = new Crestron.Logos.SplusObjects.StringOutput( VALUEFB__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( VALUEFB__AnalogSerialOutput__ + i, VALUEFB[i+1] );
        }
        
        MANAGERNAME = new StringParameter( MANAGERNAME__Parameter__, this );
        m_ParameterList.Add( MANAGERNAME__Parameter__, MANAGERNAME );
        
        VALUENAME = new StringParameter( VALUENAME__Parameter__, this );
        m_ParameterList.Add( VALUENAME__Parameter__, VALUENAME );
        
        
        for( uint i = 0; i < 32; i++ )
            VALUE[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( VALUE_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        THECONFIG  = new ConfigSystem.Simpl.ConfigValue();
        
        
    }
    
    public UserModuleClass_CONFIG_SYSTEM_V3_0_0_CONFIG_BLOCKSERIAL_AVISPL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint VALUE__AnalogSerialInput__ = 0;
    const uint VALUEFB__AnalogSerialOutput__ = 0;
    const uint MANAGERNAME__Parameter__ = 10;
    const uint VALUENAME__Parameter__ = 11;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
